namespace day_2022_12_07;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                var parts = line.Split(' ');
                Record record = parts[0] switch
                {
                    "$" => new Record.CommandRecord(parts[1] switch
                    {
                        "cd" => new Command.ChangeDirectoryCommand(parts[2] switch 
                        {
                            "/" => new ChangeDirectory.Root(),
                            ".." => new ChangeDirectory.Up(),
                            _ => new ChangeDirectory.Down(parts[2])
                        }),
                        "ls" => new Command.ListContentCommand(),
                        _ => throw new ArgumentOutOfRangeException()
                    }),
                    _ => new Record.InfoRecord(parts[0] switch
                    {
                        "dir" => new Info.DirectoryInfo(parts[1]),
                        _ => new Info.FileInfo(parts[1], int.Parse(parts[0]))
                    })
                };
                return record;
            }));
    }
}