#! python3

import os, sys, shutil

data_code = """namespace <NAMESPACE>;

public class Data
{
}"""


parser_code = """namespace <NAMESPACE>;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data();
    }
}"""

solver_code = """namespace <NAMESPACE>;

public static class Solver
{
    public static object Part1(Data data)
    {
        return null!;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}"""

solution_code = """using utils;

namespace <NAMESPACE>;

public class Solution : ISolution
{
    public static void Main()
    {
        var solution = new Solution();
        Console.WriteLine($"Part1: {solution.SolvePart1()}");
        Console.WriteLine($"Part2: {solution.SolvePart2()}");
    }

    public Solution()
    {
        _data = Parser.Parse(Input.GetData());
    }

    public object SolvePart1()
    {
        return Solver.Part1(_data);
    }

    public object SolvePart2()
    {
        return Solver.Part2(_data);
    }

    private readonly Data _data;
}"""

input_code = """namespace <NAMESPACE>;

public static class Input
{
    public static string GetData()
    {
        return @"";
    }
}"""

parser_tests_code = """namespace <NAMESPACE>;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Parser.Parse(""), Is.Not.Null);
    }
}"""

solver_tests_code = """namespace <NAMESPACE>;

public class SolverTests
{
    private const string Data = @"";

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.Null);
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}"""

project = sys.argv[1]

lib = f"{project}"
os.system(f"dotnet new classlib --no-restore -o {lib}")
os.remove(f"{lib}/Class1.cs")
with open(f"{lib}/Data.cs", "w") as f:
    f.write(data_code.replace("<NAMESPACE>", lib.replace("-", "_")))
with open(f"{lib}/Parser.cs", "w") as f:
    f.write(parser_code.replace("<NAMESPACE>", lib.replace("-", "_")))
with open(f"{lib}/Solver.cs", "w") as f:
	f.write(solver_code.replace("<NAMESPACE>", lib.replace("-", "_")))

app = f"{project}.app"
os.system(f"dotnet new console --no-restore -o {app}")
os.remove(f"{app}/Program.cs")
with open(f"{app}/Solution.cs", "w") as f:
	f.write(solution_code.replace("<NAMESPACE>", app.replace("-", "_")))
with open(f"{app}/Input.cs", "w") as f:
    f.write(input_code.replace("<NAMESPACE>", app.replace("-", "_")))

tests = f"{project}.tests"
os.system(f"dotnet new nunit --no-restore -o {tests}")
os.remove(f"{tests}/UnitTest1.cs")
with open(f"{tests}/ParserTests.cs", "w") as f:
    f.write(parser_tests_code.replace("<NAMESPACE>", tests.replace("-", "_")))
with open(f"{tests}/SolverTests.cs", "w") as f:
	f.write(solver_tests_code.replace("<NAMESPACE>", tests.replace("-", "_")))

os.system(f"dotnet add {app} reference utils")
os.system(f"dotnet add {app} reference {lib}")
os.system(f"dotnet add {tests} reference {lib}")
os.system(f"dotnet add solutions.tests reference {app}")

os.system(f"dotnet sln add {lib}")
os.system(f"dotnet sln add {app}")
os.system(f"dotnet sln add {tests}")
