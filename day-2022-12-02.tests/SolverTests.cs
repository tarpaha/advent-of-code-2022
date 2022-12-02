namespace day_2022_12_02.tests;

public class SolverTests
{
    private const string Data = @"
A Y
B X
C Z";

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(15));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(12));
    }
}