using utils;

namespace solutions.tests;

public class Tests
{
    private static IEnumerable<TestCaseData> SolutionsTestCases
    {
        get
        {
            yield return new TestCaseData(new day_2022_12_01.app.Solution(), 69693, 200945);
        }
    }
        
    [TestCaseSource(nameof(SolutionsTestCases))]
    public void Test(ISolution solution, object? result1, object? result2)
    {
        if(result1 != null)
            Assert.That(solution.SolvePart1(), Is.EqualTo(result1));
        if(result2 != null)
            Assert.That(solution.SolvePart2(), Is.EqualTo(result2));
    }
}