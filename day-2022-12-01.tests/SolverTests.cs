namespace day_2022_12_01.tests;

public class SolverTests
{
    private const string Data = @"
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(24000));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}