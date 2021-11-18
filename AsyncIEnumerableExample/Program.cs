using AsyncIEnumerableExample;
using Bogus;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => 
{
    var products = GetProducts();

    return Results.Ok(products);
});

app.Run();

static async IAsyncEnumerable<Product> GetProducts()
{
    var fake = new Faker<Product>()
        .CustomInstantiator(x => new Product
        {
            Name = x.Commerce.ProductName(),
            Price = x.Commerce.Price()
        });

    var products = fake.Generate(10);

    foreach (var item in products)
    {
        await Task.Delay(1000);
        yield return item;
    }
}