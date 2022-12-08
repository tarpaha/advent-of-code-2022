namespace day_2022_12_08.tests;

public class SolverTests
{
    private const string Data = @"
30373
25512
65332
33549
35390";

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(21));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(8));
    }
}