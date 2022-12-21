namespace day_2022_12_14.tests;

public class CaveTests
{
    private const string Data = @"
498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";

    private const string Cave = @"
......+...
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
........#.
#########.";

    [Test]
    public void CaveCreationFromData_Works_Correctly()
    {
        Assert.That(Environment.NewLine + new Cave(Parser.Parse(Data), 500, 0), Is.EqualTo(Cave));
    }
}