var path = @"C:\Users\isaac.borges\Desktop\album-v2";
var filesInfo = new DirectoryInfo(path).GetFiles("*.*");
foreach (var file in filesInfo)
{
    Console.WriteLine(file.Name);
}