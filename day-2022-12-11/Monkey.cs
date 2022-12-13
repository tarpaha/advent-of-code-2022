namespace day_2022_12_11;

public class Monkey
{
    public IEnumerable<Item> Items => _items; 
    public readonly Operation Operation;
    public readonly long Divider;
    public readonly int MonkeyTrue;
    public readonly int MonkeyFalse;

    public int Inspects { get; private set; }

    private readonly List<Item> _items;

    public Monkey(MonkeyData data)
    {
        _items = data.Items.Select(itemData => new Item(itemData.WorryLevel)).ToList();
        Operation = data.Operation;
        Divider = data.Divider;
        MonkeyTrue = data.MonkeyTrue;
        MonkeyFalse = data.MonkeyFalse;
    }

    public void GiveItem(Item item, Monkey monkey)
    {
        _items.Remove(item);
        monkey._items.Add(item);
    }

    public void Inspect(Item item)
    {
        item.ApplyOperation(Operation);
        item.ReduceWorry();
        Inspects += 1;
    }
}