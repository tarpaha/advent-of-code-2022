namespace day_2022_12_13;

public static class Solver
{
    private enum Result
    {
        Same,
        RightOrder,
        OutOfOrder
    }
    
    public static object Part1(Data data)
    {
        var result = 0;
        var index = 1;
        foreach (var (packet1, packet2) in data.Pairs)
        {
            if (ComparePackets(packet1, packet2) == Result.RightOrder)
                result += index;
            index += 1;
        }
        return result;
    }

    private static Result ComparePackets(Packet packet1, Packet packet2)
    {
        return CompareElements(packet1.List, packet2.List);
    }
    
    private static Result CompareElements(Element left, Element right)
    {
        switch (left)
        {
            case Element.List leftList:
                switch (right)
                {
                    case Element.List rightList:
                        return CompareLists(leftList.Elements.ToList(), rightList.Elements.ToList());
                    case Element.Integer rightInteger:
                        return CompareLists(leftList.Elements.ToList(), new[] { rightInteger });
                }
                break;
            case Element.Integer leftInteger:
                switch (right)
                {
                    case Element.Integer rightInteger:
                        return CompareIntegers(leftInteger, rightInteger);
                    case Element.List rightList:
                        return CompareLists(new [] { leftInteger}, rightList.Elements.ToList());
                }
                break;
        }
       throw new NotImplementedException();
    }

    private static Result CompareIntegers(Element.Integer leftElement, Element.Integer rightElement)
    {
        if (leftElement.Value < rightElement.Value)
            return Result.RightOrder;
        if (leftElement.Value > rightElement.Value)
            return Result.OutOfOrder;
        return Result.Same;
    }

    private static Result CompareLists(IReadOnlyList<Element> leftElements, IReadOnlyList<Element> rightElements)
    {
        var maxCount = Math.Max(leftElements.Count, rightElements.Count);
        for (var i = 0; i < maxCount; i++)
        {
            if (i >= leftElements.Count)
                return Result.RightOrder;
            if (i >= rightElements.Count)
                return Result.OutOfOrder;
            
            var result = CompareElements(leftElements[i], rightElements[i]);
            if (result != Result.Same)
                return result;
        }
        return Result.Same;
    }

    public static object Part2(Data data)
    {
        var packets = data.Packets().ToList();
        var dividerPacket1 = IntegerPacket(2); 
        var dividerPacket2 = IntegerPacket(6);
        packets.Add(dividerPacket1);
        packets.Add(dividerPacket2);
        packets.Sort((packet1, packet2) => ComparePackets(packet1, packet2) switch
        {
            Result.RightOrder => -1,
            Result.Same => 0,
            Result.OutOfOrder => +1,
            _ => throw new ArgumentOutOfRangeException()
        });
        return (packets.IndexOf(dividerPacket1) + 1) * (packets.IndexOf(dividerPacket2) + 1);
    }

    private static Packet IntegerPacket(int value)
    {
        return new Packet(new Element.List(new[] { new Element.List(new[] { new Element.Integer(value) }) }));
    }
}