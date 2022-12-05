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
            sum += Priority(commonItem);
        }
        return sum;
    }

    public static object Part2(Data data)
    {
        var sum = 0;
        foreach (var rucksacks in data.Rucksacks.Chunk(3))
        {
            var rucksacksArray = rucksacks.ToArray();
            var commonItem = rucksacksArray[0].Items
                .Intersect(rucksacksArray[1].Items)
                .Intersect(rucksacksArray[2].Items)
                .First();
            sum += Priority(commonItem);
        }
        return sum;
    }

    private static int Priority(Item item)
    {
        return item.Type switch
        {
            >= 'a' and <= 'z' => item.Type - 'a' + 1,
            >= 'A' and <= 'Z' => item.Type - 'A' + 27,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}