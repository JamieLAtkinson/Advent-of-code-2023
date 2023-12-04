// See https://aka.ms/new-console-template for more information
using FileHandler;
Console.WriteLine("Hello, World!");
FileReader reader = new FileReader(Environment.CurrentDirectory);
reader.LoadFileData("input.txt");
int output = 0;
int[] copies = new int[reader.GetDataLength()];
for(int i = 0; i < copies.Length; i++)
{
    copies[i] = copies[i] + 1;
}
for (int i = 0; i < reader.GetDataLength(); i++)
{
    int[][] x = ReadLine(reader);
    int wins = 0;
    for (int j = 0; j < x[0].Length; j++)
    {
        if (x[1].Contains(x[0][j])){
            wins++;
        }   
    }
    for(int j=1; j <= wins; j++) 
    {
        copies[i + j]= copies[i+j] + copies[i];
    }
}
Console.WriteLine(copies.Sum());

int[][] ReadLine(FileReader reader)
{
    string line = reader.ReadLine();
    line = line.Split(":")[1];
    string[] lines = line.Trim().Split("|");
    string[] col1 = lines[0].Split(" ");
    string[] col2 = lines[1].Split(" ");
    List<int> colo1 = new List<int>(), colo2 = new List<int>();
    foreach (string s in col1)
    {
        if (s != "")
        {
            colo1.Add(int.Parse(s));
        }
    }
    foreach (string s in col2)
    {
        if (s != "") {
            colo2.Add(int.Parse(s));
        }
    }
    return new int[][] { colo1.ToArray(), colo2.ToArray() };
} 