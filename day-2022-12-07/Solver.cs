namespace day_2022_12_07;

public static class Solver
{
    public static object Part1(Data data)
    {
        return DirectoryEntry.CreateFrom(data)
            .GetAll()
            .Where(entry => entry.IsDir && entry.SizeTotal <= 100000)
            .Sum(directory => directory.SizeTotal);
    }

    public static object Part2(Data data)
    {
        var root = DirectoryEntry.CreateFrom(data);
        var spaceToFree = 30000000 - (70000000 - root.SizeTotal);
        return root
            .GetAll()
            .Where(entry => entry.IsDir && entry.SizeTotal >= spaceToFree)
            .OrderBy(entry => entry.SizeTotal)
            .First()
            .SizeTotal;
    }
}