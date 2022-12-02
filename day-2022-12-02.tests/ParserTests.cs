namespace day_2022_12_02.tests;

public class ParserTests
{
    private const string TestData = @"
A Y
B X
C Z";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(TestData);
        Assert.That(data.Pairs.Count(), Is.EqualTo(3));
        Assert.That(data.Pairs.Select(pair => $"{pair.First}{pair.Second}").Aggregate("", (a, b) => a + b), Is.EqualTo("AYBXCZ"));
    }
}