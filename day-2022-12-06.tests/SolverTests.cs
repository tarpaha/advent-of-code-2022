namespace day_2022_12_06.tests;

public class SolverTests
{
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1(string data, int result)
    {
        Assert.That(Solver.Part1(Parser.Parse(data)), Is.EqualTo(result));
    }
    
    [Test]
    public void Part2()
    {
        Assert.Pass();
    }
}