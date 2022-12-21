namespace day_2022_12_14;

public static class Solver
{
    public static object Part1(Data data)
    {
        var cave = new Cave(data, 500, 0);
        var amount = 0;
        while (cave.DropSand())
            amount += 1;
        return amount;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}