namespace day_2022_12_14.tests;

public class InfiniteCaveTests
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
    public void CreationFromData_Works_Correctly()
    {
        Assert.That(Environment.NewLine + new InfiniteCave(Parser.Parse(Data), 500, 0), Is.EqualTo(Cave));
    }

    [TestCase(1, @"
......+...
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
......o.#.
#########.", true)]
    [TestCase(2, @"
......+...
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
.....oo.#.
#########.", true)]
    [TestCase(5, @"
......+...
..........
..........
..........
....#...##
....#...#.
..###...#.
......o.#.
....oooo#.
#########.", true)]
    [TestCase(22, @"
......+...
..........
......o...
.....ooo..
....#ooo##
....#ooo#.
..###ooo#.
....oooo#.
...ooooo#.
#########.", true)]
    [TestCase(24, @"
......+...
..........
......o...
.....ooo..
....#ooo##
...o#ooo#.
..###ooo#.
....oooo#.
.o.ooooo#.
#########.", true)]
    [TestCase(25, @"
......+...
..........
......o...
.....ooo..
....#ooo##
...o#ooo#.
..###ooo#.
....oooo#.
.o.ooooo#.
#########.", false)]
    public void DropSand_Works_Correctly(int sandAmount, string caveString, bool rested)
    {
        var cave = new InfiniteCave(Parser.Parse(Data), 500, 0);
        bool finalSandRested = false;
        for(var i = 0; i < sandAmount; i++)
            finalSandRested = cave.DropSand();
        Assert.That(Environment.NewLine + cave, Is.EqualTo(caveString));
        Assert.That(finalSandRested, Is.EqualTo(rested));
    }
}