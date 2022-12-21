namespace day_2022_12_13.tests;

public class DataTests
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
    public void Packets_Works_Correctly()
    {
        var packets = Parser.Parse(Data).Packets();
        Assert.That(
            string.Join("", packets),
            Is.EqualTo(Data.Replace($"{Environment.NewLine}", "")));
    }
}