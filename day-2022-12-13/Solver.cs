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
        return null!;
    }
}