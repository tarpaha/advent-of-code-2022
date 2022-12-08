namespace day_2022_12_08;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var cells = new int[lines.Length, lines.Length];
        var y = 0;
        foreach (var line in lines)
        {
            var x = 0;
            foreach (var ch in line)
            {
                cells[x, y] = ch - '0';
                x += 1;
            }
            y += 1;
        }
        return new Data(cells);
    }
}