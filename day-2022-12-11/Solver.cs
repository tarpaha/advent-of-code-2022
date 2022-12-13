namespace day_2022_12_11;

public static class Solver
{
    public static object Part1(Data data)
    {
        var monkeys = data.MonkeyDatas.Select(monkeyData => new Monkey(monkeyData)).ToList();
        Play(monkeys, 20);
        return monkeys
            .Select(monkey => monkey.Inspects)
            .OrderDescending()
            .Take(2)
            .ToList()
            .Aggregate(1, (a, b) => a * b);
    }

    public static void Play(IReadOnlyList<Monkey> monkeys, int rounds)
    {
        foreach (var _ in Enumerable.Range(0, rounds))
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items.ToList())
                {
                    monkey.Inspect(item);
                    monkey.GiveItem(item, monkeys[
                        item.WorryLevel % monkey.Divider == 0
                            ? monkey.MonkeyTrue
                            : monkey.MonkeyFalse
                    ]);
                }
            }
        }
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}