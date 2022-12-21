namespace day_2022_12_14.tests;

public class ParserTests
{
    private const string Data = @"
498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Environment.NewLine + Parser.Parse(Data), Is.EqualTo(Data));
    }
}