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
            yield return new TestCaseData(new day_2022_12_04.app.Solution(), 507, 897);
            yield return new TestCaseData(new day_2022_12_05.app.Solution(), "PSNRGBTFT", "BNTZFPMMW");
            yield return new TestCaseData(new day_2022_12_06.app.Solution(), 1625, 2250);
            yield return new TestCaseData(new day_2022_12_07.app.Solution(), 1453349, 2948823);
            yield return new TestCaseData(new day_2022_12_08.app.Solution(), 1794, 199272);
            yield return new TestCaseData(new day_2022_12_09.app.Solution(), 6271, 2458);
            yield return new TestCaseData(new day_2022_12_10.app.Solution(), 17940, @"
####..##..###...##....##.####...##.####.
...#.#..#.#..#.#..#....#.#.......#....#.
..#..#....###..#..#....#.###.....#...#..
.#...#....#..#.####....#.#.......#..#...
#....#..#.#..#.#..#.#..#.#....#..#.#....
####..##..###..#..#..##..#.....##..####.");
            yield return new TestCaseData(new day_2022_12_11.app.Solution(), 51075, 11741456163);
            yield return new TestCaseData(new day_2022_12_12.app.Solution(), 423, 416);
            yield return new TestCaseData(new day_2022_12_13.app.Solution(), 6568, 19493);
            yield return new TestCaseData(new day_2022_12_14.app.Solution(), 888, null);
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