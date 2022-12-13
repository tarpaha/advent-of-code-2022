namespace day_2022_12_11;

public static class Parser
{
    public static Data Parse(string data)
    {
        var monkeyDatas = new List<MonkeyData>();
        var monkeyRecords = data.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
        foreach (var monkeyRecord in monkeyRecords)
        {
            var lines = monkeyRecord.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var items = lines[1]
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)[2..]
                .Select(n => new Item(int.Parse(n)))
                .ToList();
            var operationParts = lines[2].Split(' ', StringSplitOptions.RemoveEmptyEntries)[^2..];
            Operation operation = operationParts[0] switch
            {
                "+" => new Operation.Add(long.Parse(operationParts[1])),
                "*" => operationParts[1] switch
                {
                    "old" => new Operation.Square(),
                    var x => new Operation.Mul(long.Parse(x)) 
                },
                _ => throw new ArgumentOutOfRangeException()
            };
            var divider = int.Parse(lines[3].Split(' ', StringSplitOptions.RemoveEmptyEntries)[^1]);
            var monkeyTrue = int.Parse(lines[4].Split(' ', StringSplitOptions.RemoveEmptyEntries)[^1]);
            var monkeyFalse = int.Parse(lines[5].Split(' ', StringSplitOptions.RemoveEmptyEntries)[^1]);
            monkeyDatas.Add(new MonkeyData(items, operation, divider, monkeyTrue, monkeyFalse));
        }
        return new Data(monkeyDatas);
    }
}