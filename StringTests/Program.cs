#region AC - array replace element
//Example:
//Input = [17, 18, 5, 4, 6, 1]
//Output = [18, 6, 6, 6, 1, -1]

//int[] arr = { 17, 18, 5, 4, 6, 1 };

//for (int i = 0; i < arr.Length; i++)
//{
//    if (i == arr.Length - 1)
//    {
//        arr[i] = -1;
//        continue;
//    }

//    arr[i] = arr.Skip(i + 1).Max();
//}

//foreach (var item in arr)
//{
//    Console.WriteLine(item);
//}
#endregion

#region palavra invertida
//Console.WriteLine("Informe uma palavra: ");
//var word = Console.ReadLine();

//Console.WriteLine("Palavra invertida: " + InvertedWord(word));
//Console.ReadLine();
//static string InvertedWord(string word)
//{
//    var sb = new System.Text.StringBuilder();

//    for (int i = word.Length - 1; i >= 0; i--)
//    {
//        sb.Append(word[i]);
//    }

//    return sb.ToString();
//}
#endregion

#region fibonacci
var previusNumber = 0;
var actualNumber = 1;

for (var i = 0; i < 10; i++)
{
    var number = previusNumber + actualNumber;
    Console.WriteLine(number);
    previusNumber = actualNumber;
    actualNumber = number;
}
#endregion