namespace day_2022_12_07;

public class DirectoryEntry
{
    public string Name { get; }
    public long Size { get; }
    public long SizeTotal { get; private set; }
    public DirectoryEntry? Parent { get; }

    public bool IsDir => Size == 0;
    
    private readonly List<DirectoryEntry> _entries = new();
    
    public DirectoryEntry(DirectoryEntry? parent, string name, long size = 0)
    {
        Name = name;
        Size = size;
        Parent = parent;
    }

    public DirectoryEntry AddAndReturnEntryByName(string name, long size = 0)
    {
        var entry = _entries.Find(entry => entry.Name == name);
        if (entry != null)
            return entry;
        entry = new DirectoryEntry(this, name, size);
        _entries.Add(entry);
        return entry;
    }

    public override string ToString() => ToString("");
    private string ToString(string indent)
    {
        var str = indent + $"- {Name} (" + (IsDir ? "dir" : $"file, size={Size}")  + ")" + Environment.NewLine;
        foreach (var entry in _entries.OrderBy(entry => entry.Name))
        {
            str += entry.ToString(indent + "  ");
        }
        return str;
    }

    public void UpdateTotalSize()
    {
        SizeTotal = Size;
        foreach (var entry in _entries)
        {
            entry.UpdateTotalSize();
            SizeTotal += entry.SizeTotal;
        }
    }

    public IEnumerable<DirectoryEntry> GetAll()
    {
        var result = new List<DirectoryEntry> { this };
        foreach (var entry in _entries)
        {
            result.AddRange(entry.GetAll());
        }
        return result;
    }
}

public static class FileSystem
{
    public static DirectoryEntry CreateFrom(Data data)
    {
        var root = new DirectoryEntry(null, "/");
        var current = root;
        foreach (var record in data.Records)
        {
            switch (record)
            {
                case Record.CommandRecord({ } command):
                    switch (command)
                    {
                        case Command.ListContentCommand:
                            break;
                        case Command.ChangeDirectoryCommand({ } changeDirectory):
                            switch (changeDirectory)
                            {
                                case ChangeDirectory.Root:
                                    current = root;
                                    break;
                                case ChangeDirectory.Up:
                                    current = current?.Parent;
                                    break;
                                case ChangeDirectory.Down({ } name):
                                    current = current?.AddAndReturnEntryByName(name);
                                    break;
                            }
                            break;
                    }
                    break;
                case Record.InfoRecord({ } info):
                    switch (info)
                    {
                        case Info.DirectoryInfo directoryInfo:
                            current?.AddAndReturnEntryByName(directoryInfo.Name);
                            break;
                        case Info.FileInfo fileInfo:
                            current?.AddAndReturnEntryByName(fileInfo.Name, fileInfo.Size);
                            break;
                    }
                    break;
            }
        }
        root.UpdateTotalSize();
        return root;
    }
}