namespace day_2022_12_01.tests;

public class ParserTests
{
    private const string TestData =
@"
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(TestData);
        Assert.That(data.Inventories.Count(), Is.EqualTo(5));
        Assert.That(data.Inventories.Select(inventory => inventory.Calories.Count()), Is.EquivalentTo(new [] { 3, 1, 2, 3, 1 }));
    }
}