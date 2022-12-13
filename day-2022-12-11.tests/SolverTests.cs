namespace day_2022_12_11.tests;

public class SolverTests
{
    private const string Data = @"
Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1";

    [TestCase(1, new [] { "20, 23, 27, 26", "2080, 25, 167, 207, 401, 1046", "", ""})]
    [TestCase(5, new [] { "15, 17, 16, 88, 1037", "20, 110, 205, 524, 72", "", ""})]
    [TestCase(10, new [] { "91, 16, 20, 98", "481, 245, 22, 26, 1092, 30", "", ""})]
    [TestCase(15, new [] { "83, 44, 8, 184, 9, 20, 26, 102", "110, 36", "", ""})]
    [TestCase(20, new [] { "10, 12, 14, 26, 34", "245, 93, 53, 199, 115", "", ""})]
    public void Part1_WorryLevels(int rounds, string[] items)
    {
        var monkeys = Parser.Parse(Data).MonkeyDatas.Select(monkeyData => new Monkey(monkeyData)).ToList();
        Solver.Play(monkeys, rounds);
        Assert.That(monkeys.Select(monkey => string.Join(", ", monkey.Items)), Is.EquivalentTo(items));
    }

    [TestCase(20, new [] { 101, 95, 7, 105 })]
    public void Part1_Inspects(int rounds, int[] inspects)
    {
        var monkeys = Parser.Parse(Data).MonkeyDatas.Select(monkeyData => new Monkey(monkeyData)).ToList();
        Solver.Play(monkeys, rounds);
        Assert.That(monkeys.Select(monkey => monkey.Inspects), Is.EquivalentTo(inspects));
    }

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(10605));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}