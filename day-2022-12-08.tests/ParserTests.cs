namespace day_2022_12_08.tests;

public class ParserTests
{
    private const string Data = @"
30373
25512
65332
33549
35390";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        var cells = Parser.Parse(Data).Cells;
        Assert.Multiple(() =>
        {
            Assert.That(cells.GetLength(0), Is.EqualTo(5));
            Assert.That(cells.GetLength(1), Is.EqualTo(5));
            Assert.That(cells[1, 0], Is.EqualTo(0));
            Assert.That(cells[0, 1], Is.EqualTo(2));
            Assert.That(cells[4, 4], Is.EqualTo(0));
        });
    }
}