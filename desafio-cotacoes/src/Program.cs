using NetMQ;
using NetMQ.Sockets;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri(builder.Configuration["Url:ServiceBase"]);

app.MapGet("/api/cotacoes/", async (string coin) =>
{
    coin = coin.ToUpper();

    var taskServiceA = httpClient.GetFromJsonAsync<ServicoAResponse>($"servico-a/cotacao?moeda={coin}");
    var taskServiceB = httpClient.GetFromJsonAsync<ServicoBResponse>($"servico-b/cotacao?curr={coin}");
    var taskServiceC = httpClient.PostAsJsonAsync("servico-c/cotacao", new ServicoCRequest(coin, builder.Configuration["Url:Callback"]));

    Task.WaitAll(taskServiceA, taskServiceB, taskServiceC);

    var serviceA = taskServiceA.Result;
    var serviceB = taskServiceB.Result;
    var serviceC = taskServiceC.Result;

    var callbackServiceC = await serviceC.Content.ReadFromJsonAsync<ServicoCResponse>();

    var priceA = serviceA.Cotacao;
    var priceB = decimal.Parse(serviceB.Cotacao.Valor) / serviceB.Cotacao.Fator;
    var priceC = GetCotacaoServicoC(callbackServiceC.Cid, app);

    app.Logger.LogInformation($"cotacao A: {priceA}");
    app.Logger.LogInformation($"cotacao B: {priceB}");
    app.Logger.LogInformation($"cotacao C: {priceC}");

    var bestPrice = new decimal[] { priceA, priceB, priceC }.Min();

    var response = new
    {
        cotacao = bestPrice,
        moeda = coin,
        comparativo = "BRL"
    };

    return Results.Ok(response);
});

app.MapPost("/api/cotacoes/webhook", (ServicoCCallback callback) =>
{
    app.Logger.LogInformation($"callback received: {callback}");

    try
    {
        using (var sender = new PairSocket())
        {
            sender.Connect($"inproc://{callback.Cid}");
            sender.SendFrame(Encoding.Unicode.GetBytes(JsonSerializer.Serialize(callback)));
        }

        app.Logger.LogInformation($"inproc message sent to inproc://{callback.Cid}");
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, $"error sending inproc message to inproc://{callback.Cid}");
    }

    return Results.NoContent();
});

app.Run();

static decimal GetCotacaoServicoC(string correlationId, WebApplication app)
{
    var cotacaoServicoC = decimal.MaxValue;

    using (var receiver = new PairSocket())
    {
        receiver.Bind($"inproc://{correlationId}");

        var payload = string.Empty;
        if (receiver.TryReceiveFrameString(TimeSpan.FromSeconds(5), Encoding.Unicode, out payload))
        {
            var callbackRequest = JsonSerializer.Deserialize<ServicoCCallback>(payload);
            cotacaoServicoC = callbackRequest.V / callbackRequest.F;
            app.Logger.LogInformation($"callback received: {callbackRequest}");
        }
        else
        {
            app.Logger.LogInformation($"callback not timely received");
        }
    }

    return cotacaoServicoC;
}

public record ServicoAResponse(decimal Cotacao, string Moeda);

public record ServicoBResponse(ServicoBCotacaoResponse Cotacao);
public record ServicoBCotacaoResponse(int Fator, string Currency, string Valor);

public record ServicoCRequest(string Tipo, string CallBack);
public record ServicoCResponse(string Cid, string Mensagem);
public record ServicoCCallback(string Cid, int F, string T, decimal V);