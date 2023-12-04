// See https://aka.ms/new-console-template for more information
using FileHandler;
Console.WriteLine("Hello, World!");

FileReader reader = new FileReader(Environment.CurrentDirectory);
reader.LoadFileData("input.txt");
char[][] grid = new char[reader.GetDataLength()][];
for(int i=0;i<grid.GetLength(0); i++)
{
    grid[i] = ReadLine(reader);
}
int numlength = 0;
int currentNumber = 0, output = 0,y=0;
for(int i = 0; i < grid.GetLength(0); i++)
{
    for(int rowpointer = 0; rowpointer < grid[i].GetLength(0); rowpointer++)
    {
        if (grid[i][rowpointer] == '*')
        {
            int[] x = FindSurroundingNumbers(grid, i, rowpointer);
            if(x.Length == 2)
            {
                output+= x[0]*x[1];
                Console.WriteLine(x[0] * x[1]);
            }
        }
    }
}
Console.WriteLine(output);


char[] ReadLine(FileReader reader)
{
    string line = reader.ReadLine();
    return line.ToCharArray();
}

bool NextToSymbol(char[][] grid,int x,int y)
{
    char[] notsymbols = {'.','1','2','3','4','5','6','7','8','9','0'};
    int n = clamp(y + 1,grid.GetLength(0)-1,0), s = clamp(y - 1,grid.GetLength(0)-1,0), e = clamp(n + 1, grid[x].GetLength(0)-1,0), w = clamp(n - 1, grid[x].GetLength(0)-1,0);
    if (!notsymbols.Contains(grid[y][w]) ||
        !notsymbols.Contains(grid[y][e]) ||
        !notsymbols.Contains(grid[n][x]) ||
        !notsymbols.Contains(grid[s][x]) ||
        !notsymbols.Contains(grid[n][w]) ||
        !notsymbols.Contains(grid[n][e]) ||
        !notsymbols.Contains(grid[s][w]) ||
        !notsymbols.Contains(grid[s][e]))
    {
        return true;
    }
    return false;
}

int clamp(int input,int max,int min)
{
    if (input < min)
    {
        return min;
    }
    if (input > max) { return max;}
    return input;
}

int[] FindSurroundingNumbers(char[][] grid,int x, int y)
{
    HashSet<int> result = new HashSet<int>();
    int z = 0;
    for (int i = -1; i < 2; i++)
    {
        for(int j = -1; j < 2; j++)
        {
            //Console.Write(grid[x + i][y + j]);
            if (int.TryParse(grid[x + i][y + j].ToString(), out z))
            {
                
                if (!(grid[x + i][y + j] == '*'))
                {
                    int t = getNumber(grid, x + i, y + j);
                    Console.WriteLine(t);
                    result.Add(t);
                    
                }
            }
        }
        //Console.WriteLine();
    }
    return result.ToArray();
}
int getNumber(char[][] grid, int x, int y)
{
    char selection = grid[x][y];
    int a=x,b=y-1,output=0,pow = 0;
    do
    {
        b++;
        try
        {
            selection = grid[x][b];
            
        }
        catch { break; }
        
    } while (int.TryParse(selection.ToString(), out _));
    b--;
    do
    {
        string t = grid[a][b].ToString();
        output += int.Parse(t) * (int)Math.Pow(10, pow);
        b--;
        if (b < 0)
        {
            break;
        }
        pow++;
    } while (int.TryParse(grid[a][b].ToString(),out _));
    return output;
}