namespace day_2022_12_13;

public abstract record Element
{
    public record Integer(int Value) : Element
    {
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public record List(IEnumerable<Element> Elements) : Element
    {
        public override string ToString()
        {
            return "[" + string.Join(',', Elements) + "]";
        }
    }
}

public record Packet(Element.List List)
{
    public override string ToString()
    {
        return List.ToString();
    }
}

public record Pair(Packet Packet1, Packet Packet2)
{
    public override string ToString()
    {
        return Packet1 + Environment.NewLine + Packet2;
    }
}

public record Data(IEnumerable<Pair> Pairs)
{
    public override string ToString()
    {
        return string.Join($"{Environment.NewLine}{Environment.NewLine}", Pairs);
    }
}