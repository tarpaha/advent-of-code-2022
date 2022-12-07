namespace day_2022_12_07.tests;

public class FileSystemTests
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
    public void FileSystem_Creates_Properly()
    {
        var root = FileSystem.CreateFrom(Parser.Parse(Data));
        Assert.That(Environment.NewLine + root, Is.EqualTo(@"
- / (dir)
  - a (dir)
    - e (dir)
      - i (file, size=584)
    - f (file, size=29116)
    - g (file, size=2557)
    - h.lst (file, size=62596)
  - b.txt (file, size=14848514)
  - c.dat (file, size=8504156)
  - d (dir)
    - d.ext (file, size=5626152)
    - d.log (file, size=8033020)
    - j (file, size=4060174)
    - k (file, size=7214296)
"));
    }

    [TestCase("e", 584)]
    [TestCase("a", 94853)]
    [TestCase("d", 24933642)]
    [TestCase("/", 48381165)]
    public void FileSystem_CalculateTotalSizes_Properly(string directoryName, long sizeTotal)
    {
        var directory = FileSystem.CreateFrom(Parser.Parse(Data))
            .GetAll()
            .First(entry => entry.Name == directoryName);
        Assert.That(directory.SizeTotal, Is.EqualTo(sizeTotal));
    }
}