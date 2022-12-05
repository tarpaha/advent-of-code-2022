using utils;

namespace solutions.tests;

public class Tests
{
    private static IEnumerable<TestCaseData> SolutionsTestCases
    {
        get
        {
            yield return new TestCaseData(new day_2022_12_01.app.Solution(), 69693, 200945);
            yield return new TestCaseData(new day_2022_12_02.app.Solution(), 13565, 12424);
            yield return new TestCaseData(new day_2022_12_03.app.Solution(), 8123, 2620);
            yield return new TestCaseData(new day_2022_12_04.app.Solution(), 507, null);
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