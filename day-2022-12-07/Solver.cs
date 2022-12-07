namespace day_2022_12_07;

public static class Solver
{
    public static object Part1(Data data)
    {
        return FileSystem.CreateFrom(data)
            .GetAll()
            .Where(entry => entry.IsDir && entry.SizeTotal <= 100000)
            .Sum(directory => directory.SizeTotal);
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}