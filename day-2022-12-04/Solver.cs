namespace day_2022_12_04;

public static class Solver
{
    public static object Part1(Data data)
    {
        var result = 0;
        foreach (var (first, second) in data.Pairs)
        {
            if ((first.Min <= second.Min && first.Max >= second.Max) ||
                (second.Min <= first.Min && second.Max >= first.Max))
                result += 1;
        }
        return result;
    }

    public static object Part2(Data data)
    {
        var result = 0;
        foreach (var (first, second) in data.Pairs)
        {
            if ((second.Min <= first.Min && first.Min <= second.Max) ||
                (second.Min <= first.Max && first.Max <= second.Max) ||
                (first.Min <= second.Min && second.Min <= first.Max) ||
                (first.Min <= second.Max && second.Max <= first.Max))
                result += 1;
        }
        return result;
    }
}