namespace day_2022_12_01;

public static class Solver
{
    public static object Part1(Data data)
    {
        return data.Inventories.Select(inventory => inventory.Calories.Sum()).Max();
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}