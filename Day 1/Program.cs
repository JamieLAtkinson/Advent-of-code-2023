// See https://aka.ms/new-console-template for more information
using FileHandler;
using System.Runtime.ExceptionServices;

Console.WriteLine("Hello, World!");
FileReader reader = new FileReader(Environment.CurrentDirectory);
reader.LoadFileData("input.txt.txt");
int output = 0;
for (int i = 0;i< reader.GetDataLength(); i++)
{
    output = output + readDataIntify(reader);
}
Console.WriteLine(output);
int readData(FileReader fileReader)
{
    string str = fileReader.ReadLine();
    int FirstInt = 0,SecondInt = 0;
    for (int i = 0; i < str.Length; i++)
    {
        char c = str[i];
        if (int.TryParse(c.ToString(),out FirstInt))
        {
            break;
        }
    }
    for (int i =str.Length - 1; i >= 0; i--)
    {
        char c = str[i];
        if (int.TryParse(c.ToString(), out SecondInt))
        {
            break;
        }
    }
    return FirstInt*10 + SecondInt;
}
int readDataIntify(FileReader fileReader)
{
    string str = fileReader.ReadLine();
    str = str.Replace("one","o1e")
        .Replace("two","t2o")
        .Replace("three","t3e")
        .Replace("four","f4r")
        .Replace("five","f5e")
        .Replace("six","s6x")
        .Replace("seven","s7n")
        .Replace("eight","e8t")
        .Replace("nine","n9e");
    int FirstInt = 0, SecondInt = 0;
    for (int i = 0; i < str.Length; i++)
    {
        char c = str[i];
        if (int.TryParse(c.ToString(), out FirstInt))
        {
            break;
        }
    }
    for (int i = str.Length - 1; i >= 0; i--)
    {
        char c = str[i];
        if (int.TryParse(c.ToString(), out SecondInt))
        {
            break;
        }
    }
    Console.WriteLine(FirstInt * 10 + SecondInt);
    return FirstInt * 10 + SecondInt;
}