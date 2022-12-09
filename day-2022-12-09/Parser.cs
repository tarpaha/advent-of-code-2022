namespace day_2022_12_09;

public static class Parser
{
    public static Data Parse(string data)
    {
        var steps = new List<Step>();
        foreach (var line in data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = line.Split(' ');
            var direction = parts[0][0] switch
            {
                'U' => Direction.Up,
                'D' => Direction.Down,
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new ArgumentOutOfRangeException()
            };
            var length = int.Parse(parts[1]);
            steps.AddRange(Enumerable.Range(0, length).Select(_ => new Step(direction)));
        }
        return new Data(steps);
    }
}