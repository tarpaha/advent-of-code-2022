using utils;

namespace day_2022_12_06.app;

public class Solution : ISolution
{
    public static void Main()
    {
        var solution = new Solution();
        Console.WriteLine($"Part1: {solution.SolvePart1()}");
        Console.WriteLine($"Part2: {solution.SolvePart2()}");
    }

    public Solution()
    {
        _data = Parser.Parse(Input.GetData());
    }

    public object SolvePart1()
    {
        return Solver.Part1(_data);
    }

    public object SolvePart2()
    {
        return Solver.Part2(_data);
    }

    private readonly Data _data;
}