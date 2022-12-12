namespace day_2022_12_10;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(' '))
            .Select(parts => (Instruction)(parts[0] switch
            {
                "noop" => new Instruction.Noop(),
                "addx" => new Instruction.AddX(int.Parse(parts[1])),
                _ => throw new ArgumentOutOfRangeException()
            }))
            .ToList());
    }
}