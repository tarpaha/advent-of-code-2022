namespace day_2022_12_12;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;
        
        var grid = new int[width, height];
        var start = (0, 0);
        var end = (0, 0);
        
        for (var y = 0; y < height; y++)
        {
            var line = lines[y];
            for (var x = 0; x < width; x++)
            {
                grid[x, y] = line[x] switch
                {
                    'S' => 'a' - 'a',
                    'E' => 'z' - 'a',
                    var ch => ch - 'a'
                };
                if (line[x] == 'S')
                    start = (x, y);
                if (line[x] == 'E')
                    end = (x, y);
            }
        }
        
        return new Data(grid, start, end);
    }
}