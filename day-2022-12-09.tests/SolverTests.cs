namespace day_2022_12_09.tests;

public class SolverTests
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
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(13));
    }
    
    private const string DataExt = @"
R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20";

    [Test]
    public void Part2Ext()
    {
        Assert.That(Solver.Part2(Parser.Parse(DataExt)), Is.EqualTo(36));
    }
}