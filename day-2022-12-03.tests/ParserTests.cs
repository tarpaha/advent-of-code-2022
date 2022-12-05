namespace day_2022_12_03.tests;

public class ParserTests
{
    private const string Data = @"
abc
def";

    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(Data);
        Assert.That(
            data.Rucksacks.Select(rucksack => rucksack.Items.Select(item => item.Type)),
            Is.EquivalentTo(new [] { "abc", "def" }));
    }
}