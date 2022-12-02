namespace day_2022_12_02.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Parser.Parse(""), Is.Not.Null);
    }
}