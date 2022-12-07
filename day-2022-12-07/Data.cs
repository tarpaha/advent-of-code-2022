namespace day_2022_12_07;

public record Data(IEnumerable<Record> Records);

public abstract record Record
{
    public record CommandRecord(Command Command) : Record;
    public record InfoRecord(Info Info) : Record;
}

public abstract record Command
{
    public record ChangeDirectoryCommand(ChangeDirectory ChangeDirectory) : Command;
    public record ListContentCommand : Command;
}

public abstract record ChangeDirectory
{
    public record Root : ChangeDirectory;
    public record Up : ChangeDirectory;
    public record Down(string Directory) : ChangeDirectory;
}

public abstract record Info
{
    public record DirectoryInfo(string Name) : Info;
    public record FileInfo(string Name, long Size) : Info;
}