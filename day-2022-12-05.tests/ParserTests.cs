namespace day_2022_12_05.tests;

public class ParserTests
{
    private const string Data = @"
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(Data);
        
        Assert.That(data.Stacks.Count(), Is.EqualTo(3));
        Assert.That(data.Stacks.Select(s => string.Join("", s.Crates)), Is.EquivalentTo(new [] {"ZN", "MCD", "P"}));
        
        Assert.That(data.Moves.Count(), Is.EqualTo(4));
    }
}