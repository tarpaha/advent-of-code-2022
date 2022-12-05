namespace day_2022_12_04.tests;

public class ParserTests
{
    private const string Data = @"
2-4,6-8
2-3,4-5";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Parser.Parse(Data).Pairs, Is.EquivalentTo(new []
        {
            (new Pair(2,4), new Pair(6,8)),
            (new Pair(2,3), new Pair(4,5))
        }));
    }
}