namespace day_2022_12_09.tests;

public class ParserTests
{
    private const string Data = @"
R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

    [Test]
    public void Parser_Works_Correctly()
    {
        var steps = Parser.Parse(Data).Steps.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(steps, Has.Count.EqualTo(24));
            Assert.That(steps.Take(4), Is.EquivalentTo(Enumerable.Range(0, 4).Select(_ => new Step(Direction.Right))));
            Assert.That(steps.Skip(4).Take(4), Is.EquivalentTo(Enumerable.Range(0, 4).Select(_ => new Step(Direction.Up))));
            Assert.That(steps.Skip(8).Take(3), Is.EquivalentTo(Enumerable.Range(0, 3).Select(_ => new Step(Direction.Left))));
            Assert.That(steps.TakeLast(2), Is.EquivalentTo(Enumerable.Range(0, 2).Select(_ => new Step(Direction.Right))));
        });
    }
}