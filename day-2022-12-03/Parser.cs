namespace day_2022_12_03;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => new Rucksack(line.Select(ch => new Item(ch)))));
    }
}