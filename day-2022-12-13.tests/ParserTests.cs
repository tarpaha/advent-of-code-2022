namespace day_2022_12_13.tests;

public class ParserTests
{
    private const string Data = @"
[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]";
    
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Environment.NewLine + Parser.Parse(Data), Is.EqualTo(Data));
    }
}