namespace day_2022_12_10.tests;

public class ParserTests
{
    private const string Data = @"
noop
addx 3
addx -5";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        var instructions = Parser.Parse(Data).Instructions.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(instructions, Has.Count.EqualTo(3));
            Assert.That(instructions, Is.EquivalentTo(new Instruction[]
            {
                new Instruction.Noop(),
                new Instruction.AddX(3),
                new Instruction.AddX(-5),
            }));
        });
    }
}