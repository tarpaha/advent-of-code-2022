namespace day_2022_12_14;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(coord => coord.Split(','))
                .Select(coord => (x: int.Parse(coord[0]), y: int.Parse(coord[1])))
                .ToList())
            .Select(coords => new Path(coords))
            .ToList());
    }
}