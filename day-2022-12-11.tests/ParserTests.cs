namespace day_2022_12_11.tests;

public class ParserTests
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

    private static IEnumerable<TestCaseData> ParserTestCases
    {
        get
        {
            yield return new TestCaseData(0, new [] { 79, 98 }, new Operation.Mul(19), 23, 2, 3);
            yield return new TestCaseData(1, new [] { 54, 65, 75, 74 }, new Operation.Add(6), 19, 2, 0);
            yield return new TestCaseData(2, new [] { 79, 60, 97 }, new Operation.Square(), 13, 1, 3);
            yield return new TestCaseData(3, new [] { 74 }, new Operation.Add(3), 17, 0, 1);
        }
    }
    
    [TestCaseSource(nameof(ParserTestCases))]
    public void Parser_Works_Correctly(int id, int [] items, Operation operation, long divider, int monkeyTrue, int monkeyFalse)
    {
        var monkeyData = Parser.Parse(Data).MonkeyDatas.ToList()[id];
        Assert.Multiple(() =>
        {
            Assert.That(monkeyData.Items.Select(item => item.WorryLevel), Is.EquivalentTo(items));
            Assert.That(monkeyData.Operation, Is.EqualTo(operation));
            Assert.That(monkeyData.Divider, Is.EqualTo(divider));
            Assert.That(monkeyData.MonkeyTrue, Is.EqualTo(monkeyTrue));
            Assert.That(monkeyData.MonkeyFalse, Is.EqualTo(monkeyFalse));
        });
    }
}