namespace day_2022_12_07.tests;

public class ParserTests
{
    private const string Data = @"
$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(Data);
        Assert.That(data.Records.Count(record => record is Record.CommandRecord(Command.ChangeDirectoryCommand(ChangeDirectory.Root))), Is.EqualTo(1)); 
        Assert.That(data.Records.Count(record => record is Record.CommandRecord(Command.ChangeDirectoryCommand(ChangeDirectory.Up))), Is.EqualTo(2)); 
        Assert.That(data.Records.Count(record => record is Record.CommandRecord(Command.ChangeDirectoryCommand(ChangeDirectory.Down))), Is.EqualTo(3)); 
        Assert.That(data.Records.Count(record => record is Record.CommandRecord(Command.ListContentCommand)), Is.EqualTo(4)); 
        Assert.That(data.Records.Count(record => record is Record.InfoRecord(Info.DirectoryInfo)), Is.EqualTo(3));
        Assert.That(data.Records.Count(record => record is Record.InfoRecord(Info.FileInfo)), Is.EqualTo(10));
    }
}