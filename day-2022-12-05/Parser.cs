namespace day_2022_12_05;

public static class Parser
{
    public static Data Parse(string data)
    {
        if (string.IsNullOrEmpty(data))
            return null!;
        
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        var firstMoveIndex = lines.FindIndex(line => line.StartsWith("move"));

        var stacksCount = int.Parse(lines[firstMoveIndex - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());
        var stackLines = lines.GetRange(0, firstMoveIndex - 1);

        var stackCrates = Enumerable.Range(0, stacksCount).Select(_ => new List<char>()).ToList();
        for (var id = stackLines.Count - 1; id >= 0; id--)
        {
            for (var s = 0; s < stacksCount; s++)
            {
                var ch = stackLines[id][1 + s * 4];
                if(ch != ' ')
                    stackCrates[s].Add(ch);
            }
        }

        var moves = new List<Move>();
        for (var id = firstMoveIndex; id < lines.Count; id++)
        {
            var parts = lines[id].Split(' ');
            moves.Add(new Move(
                int.Parse(parts[1]),
                int.Parse(parts[3]),
                int.Parse(parts[5])));
        }
        
        return new Data(stackCrates.Select(s => new Stack(s)), moves);
    }
}