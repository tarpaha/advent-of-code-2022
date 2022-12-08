namespace day_2022_12_08;

public static class Solver
{
    public static object Part1(Data data)
    {
        var cells = data.Cells;
        var size = cells.GetLength(0);
        var visibility = new int[size, size];
        
        for (var x = 0; x < size; x++)
        {
            ComputeVisibility(cells, x,        0, 0, +1, size, visibility);
            ComputeVisibility(cells, x, size - 1, 0, -1, size, visibility);
        }
        
        for (var y = 0; y < size; y++)
        {
            ComputeVisibility(cells,        0, y, +1, 0, size, visibility);
            ComputeVisibility(cells, size - 1, y, -1, 0, size, visibility);
        }

        return visibility.Cast<int>().Count(v => v > 0);
    }

    private static void ComputeVisibility(int[,] cells, int x, int y, int dx, int dy, int size, int[,] visibility)
    {
        var maxHeight = -1;
        while (x >= 0 && x < size && y >= 0 && y < size)
        {
            if (cells[x, y] > maxHeight)
            {
                visibility[x, y] += 1;
                maxHeight = cells[x, y];
            }
            x += dx;
            y += dy;
        }
    }

    public static object Part2(Data data)
    {
        var cells = data.Cells;
        var size = cells.GetLength(0);

        var distances = Task.WhenAll(
                Task.Run(() => ComputeViewingDistance(cells, +1,  0, size)),
                Task.Run(() => ComputeViewingDistance(cells, -1,  0, size)),
                Task.Run(() => ComputeViewingDistance(cells,  0, +1, size)),
                Task.Run(() => ComputeViewingDistance(cells,  0, -1, size)))
            .Result
            .Select(distances => distances.Cast<int>().ToList())
            .ToList();

        return Enumerable
            .Range(0, size * size)
            .Select(id =>
                distances[0][id] *
                distances[1][id] *
                distances[2][id] *
                distances[3][id])
            .Max();
    }

    private static int[,] ComputeViewingDistance(int[,] cells, int dx, int dy, int size)
    {
        var distances = new int[size, size];
        for (var y = 0; y < size; y++)
        for (var x = 0; x < size; x++)
            distances[x, y] = ComputeViewingDistance(cells, x, y, dx, dy, size);
        return distances;
    }

    private static int ComputeViewingDistance(int[,] cells, int x, int y, int dx, int dy, int size)
    {
        var height = cells[x, y];
        var distance = 0;
        while (x > 0 && x < size-1 && y > 0 && y < size-1)
        {
            distance += 1;
            x += dx;
            y += dy;
            if (cells[x, y] >= height)
                break;
        }
        return distance;
    }
}