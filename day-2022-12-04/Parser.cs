namespace day_2022_12_04;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(',', '-').Select(int.Parse).ToArray())
            .Select(arr => (new Pair(arr[0], arr[1]), new Pair(arr[2], arr[3]))));
    }
}