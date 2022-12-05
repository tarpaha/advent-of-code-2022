namespace day_2022_12_05;

public static class Solver
{
    public static object Part1(Data data)
    {
        var stacks = data.Stacks.Select(stack => new Stack<char>(stack.Crates)).ToList();
        foreach (var move in data.Moves)
        {
            for(var step = 0; step < move.Count; step++)
                stacks[move.To - 1].Push(stacks[move.From - 1].Pop());
        }
        return string.Join("", stacks.Select(stack => stack.Pop()));
    }

    public static object Part2(Data data)
    {
        var stacks = data.Stacks.Select(stack => new Stack<char>(stack.Crates)).ToList();
        var tmp = new Stack<char>();
        foreach (var move in data.Moves)
        {
            tmp.Clear();
            for(var step = 0; step < move.Count; step++)
                tmp.Push(stacks[move.From - 1].Pop());
            for(var step = 0; step < move.Count; step++)
                stacks[move.To - 1].Push(tmp.Pop());
        }
        return string.Join("", stacks.Select(stack => stack.Pop()));
    }
}