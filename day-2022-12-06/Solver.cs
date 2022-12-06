namespace day_2022_12_06;

public static class Solver
{
    public static object Part1(Data data)
    {
        return MarkerPosition(data.Characters.ToArray(), 4);
    }

    public static object Part2(Data data)
    {
        return MarkerPosition(data.Characters.ToArray(), 14);
    }

    private static int MarkerPosition(char[] chars, int markerSize)
    {
        for (var p = 0; p < chars.Length; p++)
        {
            if (new HashSet<char>(chars[p..(p + markerSize)]).Count == markerSize)
                return p + markerSize;
        }
        throw new ArgumentException();
    }
}