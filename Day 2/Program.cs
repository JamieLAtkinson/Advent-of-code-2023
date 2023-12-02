// See https://aka.ms/new-console-template for more information
using FileHandler;
Console.WriteLine("Hello, World!");

FileReader reader = new FileReader(Environment.CurrentDirectory);
reader.LoadFileData("input.txt");
int output = 0, power = 0;
for (int i = 0; i < reader.GetDataLength(); i++)
{
    int[] temp = ReadData(reader);
    output += temp[0];
    power += temp[1];
}
Console.WriteLine(output);
Console.WriteLine(power);
int[] ReadData(FileReader reader)
{
    int red = 12, green= 13, blue=14;
    int minred = 0, mingreen = 0, minblue = 0;
    string data = reader.ReadLine();
    string[] game = data.Split(':');
    int id = int.Parse(game[0].Replace("Game ", ""));
    string[] datas = game[1].Split(";");
    bool possible = true;
    foreach(string s in datas)
    {
        string[] x = s.Split(',');
        foreach (string y in x)
        {
            string[] z = y.Split(" ");
            string[] temp = { "" };
            z = z.Except<string>(temp).ToArray();
            switch (z[1]){
                case "red":
                    if (int.Parse(z[0]) > red)
                    {
                        possible = false;
                    }
                    if (int.Parse(z[0]) > minred) { minred = int.Parse(z[0]); }
                    break;
                case "green":
                    if (int.Parse(z[0]) > green)
                    {
                        possible = false;
                    }
                    if (int.Parse(z[0]) > mingreen) { mingreen = int.Parse(z[0]); }
                    break;
                case "blue":
                    if (int.Parse(z[0]) > blue)
                    {
                        possible = false;
                    }
                    if (int.Parse(z[0]) > minblue) { minblue = int.Parse(z[0]); }
                    break;

            }
        }
    }
    int power = minred * mingreen * minblue;
    if (!possible) { id = 0; }
    int[] output = { id, power };
    return output;
}