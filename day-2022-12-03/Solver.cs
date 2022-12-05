namespace day_2022_12_03;

public static class Solver
{
    public static object Part1(Data data)
    {
        var sum = 0;
        foreach (var rucksack in data.Rucksacks)
        {
            var items = new List<Item>(rucksack.Items);
            var halfLength = items.Count / 2;
            var commonItem = items
                .Take(halfLength).Intersect(items.Skip(halfLength).Take(halfLength))
                .First();
            var priority = commonItem.Type switch
            {
                >= 'a' and <= 'z' => commonItem.Type - 'a' + 1,
                >= 'A' and <= 'Z' => commonItem.Type - 'A' + 27,
                _ => throw new ArgumentOutOfRangeException()
            };
            sum += priority;
        }
        return sum;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}