namespace day_2022_12_06.tests;

public class ParserTests
{
    private const string Data = @"abc";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Parser.Parse(Data).Characters, Is.EquivalentTo(Data));
    }
}