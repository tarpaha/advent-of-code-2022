namespace day_2022_12_06;

public static class Solver
{
    public static object Part1(Data data)
    {
        var chars = data.Characters.ToArray();
        for (var p = 0; p < chars.Length; p++)
        {
            if (new HashSet<char>(chars[p..(p + 4)]).Count == 4)
                return p + 4;
        }
        throw new ArgumentException();
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}