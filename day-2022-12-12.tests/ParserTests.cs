namespace day_2022_12_12.tests;

public class ParserTests
{
    private const string Data = @"
Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(Data);
        Assert.Multiple(() =>
        {
            Assert.That(data.Grid.GetLength(0), Is.EqualTo(8));
            Assert.That(data.Grid.GetLength(1), Is.EqualTo(5));
            
            Assert.That(data.Start, Is.EqualTo((0, 0)));
            Assert.That(data.End, Is.EqualTo((5, 2)));
            
            Assert.That(data.Grid[data.Start.x, data.Start.y], Is.EqualTo(0));
            Assert.That(data.Grid[data.End.x, data.End.y], Is.EqualTo('z' - 'a'));
        });
    }
}