Console.WriteLine("Desafio piramide!");
Console.WriteLine("-----");

Console.WriteLine("Digite a altura da piramide:");
var alturaLeitura = Console.ReadLine();
int.TryParse(alturaLeitura, out int alturaMaxima);

if (alturaMaxima < 3 || alturaMaxima > 8)
{
    Console.WriteLine("Valor inválido");
    return;
}

PiramideEsquerda();
PiramideDireita();
PiramideCompleta();
PiramideCompletaEspacos();

Console.ReadLine();

void PiramideEsquerda()
{
    Console.WriteLine();
    Console.WriteLine("Piramide esquerda");
    for (int nivel = 1; nivel <= alturaMaxima; nivel++)
    {
        var linhaPiramide = new string('#', nivel);
        Console.WriteLine(linhaPiramide);
    }
}

void PiramideDireita()
{
    Console.WriteLine();
    Console.WriteLine("Piramide direita");
    for (int nivel = 1; nivel <= alturaMaxima; nivel++)
    {
        var qtdEspacosVazios = alturaMaxima - nivel;
        var espacosVazios = new string(' ', qtdEspacosVazios);
        var linhaPiramide = new string('#', nivel);
        Console.WriteLine(espacosVazios + linhaPiramide);
    }
}

void PiramideCompleta()
{
    Console.WriteLine();
    for (var i = 1; i <= alturaMaxima; i++)
    {
        for (var j = 1; j < alturaMaxima - i + 1; j++)
        {
            Console.Write(" ");
        }

        for (int k = 1; k < i * 2; k++)
        {
            Console.Write("#");
        }

        Console.WriteLine();
    }
}

void PiramideCompletaEspacos()
{
    Console.WriteLine();
    for (var nivel = 1; nivel <= alturaMaxima; nivel++)
    {
        var texto = string.Join(" ", Enumerable.Repeat("#", nivel));
        var linhaPiramide = texto.PadLeft(alturaMaxima - nivel + texto.Length);
        Console.WriteLine(linhaPiramide);
    }
}