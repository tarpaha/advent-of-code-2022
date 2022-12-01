namespace day_2022_12_01;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
            .Select(lines => lines
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse))
            .Select(calories => new Inventory(calories)));
    }
}