namespace day_2022_12_13;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(
            data.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
                .Select(block => block.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
                .Select(lines => new Pair(ParsePacket(lines[0]), ParsePacket(lines[1])))
                .ToList());
    }

    private static Packet ParsePacket(string str)
    {
        var (listElement, _) = ParseListElement(str);
        return new Packet(listElement);
    }
    
    private static (Element, int) ParseElement(string str, int pos)
    {
        return char.IsDigit(str[pos])
            ? ParseIntegerElement(str, pos)
            : ParseListElement(str, pos);
    }

    private static (Element.Integer, int) ParseIntegerElement(string str, int pos = 0)
    {
        var value = 0;
        while (pos < str.Length && char.IsDigit(str[pos]))
        {
            value = value * 10 + str[pos] - '0';
            pos += 1;
        }
        return (new Element.Integer(value), pos);
    }

    private static (Element.List, int) ParseListElement(string str, int pos = 0)
    {
        var elements = new List<Element>();
        pos += 1;
        while (str[pos] != ']')
        {
            if (str[pos] == ',')
            {
                pos += 1;
                continue;
            }
            var (element, newPos) = ParseElement(str, pos);
            elements.Add(element);
            pos = newPos;
        }
        return (new Element.List(elements), pos + 1); 
    }
}