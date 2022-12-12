namespace day_2022_12_10;

public static class Solver
{
    public static object Part1(Data data)
    {
        var cycles = new Queue<int>(new[] { 20, 60, 100, 140, 180, 220 });
        var result = 0L;
        var x = 1L;
        var cycle = 0;
        var target = cycles.Dequeue();
        foreach (var instruction in data.Instructions)
        {
            var instructionCycles = instruction switch
            {
                Instruction.Noop => 1,
                Instruction.AddX => 2,
                _ => throw new ArgumentOutOfRangeException()
            };
            for (var i = 0; i < instructionCycles; i++)
            {
                cycle += 1;
                if (cycle == target)
                {
                    result += x * target;
                    if (cycles.Count == 0)
                        return result;
                    target = cycles.Dequeue();
                }
            }
            switch (instruction)
            {
                case Instruction.Noop:
                    break;
                case Instruction.AddX(var v):
                    x += v;
                    break;
            }
        }
        throw new InvalidDataException();
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}