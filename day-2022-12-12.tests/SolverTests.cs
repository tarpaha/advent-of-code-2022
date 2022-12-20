namespace day_2022_12_12.tests;

public class SolverTests
{
    private const string Data = @"
Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(31));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}