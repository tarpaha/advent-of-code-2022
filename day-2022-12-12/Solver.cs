namespace day_2022_12_12;

public static class Solver
{
    public static object Part1(Data data)
    {
        var (width, height) = (data.Grid.GetLength(0), data.Grid.GetLength(1));
        var grid = new int[width, height];
        for(var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
            grid[x, y] = -1;

        var points = new HashSet<(int x, int y)>();
        var steps = 0;
        points.Add((data.Start.x, data.Start.y));

        int? result = null; 
        while(points.Count > 0)
        {
            var newPoints = new HashSet<(int x, int y)>();
            
            foreach (var (x, y) in points)
            {
                if (x == data.End.x && y == data.End.y)
                {
                    result = steps;
                    break;
                }

                grid[x, y] = steps;
                
                if (x > 0 && data.Grid[x - 1, y] - data.Grid[x, y] <= 1 && grid[x - 1, y] < 0)
                    newPoints.Add((x - 1, y));
                if (x < width - 1 && data.Grid[x + 1, y] - data.Grid[x, y] <= 1 && grid[x + 1, y] < 0)
                    newPoints.Add((x + 1, y));
                if (y > 0 && data.Grid[x, y - 1] - data.Grid[x, y] <= 1 && grid[x, y - 1] < 0)
                    newPoints.Add((x, y - 1));
                if (y < height - 1 && data.Grid[x, y + 1] - data.Grid[x, y] <= 1 && grid[x, y + 1] < 0)
                    newPoints.Add((x, y + 1));
            }

            if (result.HasValue)
                break;
            
            points = newPoints;
            steps += 1;
        }

        return result!;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}