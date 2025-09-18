namespace Tests;

using Advent2024;

public class Day1Test
{
    private readonly Day1 day1;
    private static readonly string acceptance = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";
    public Day1Test()
    {
        day1 = new Day1();
    }
    [Fact]
    public void AcceptanceTest1()
    {
        Assert.Equal(11, day1.GetTotalDistance(acceptance));
    }

    [Fact]
    public void Part1()
    {

        string input = File.ReadAllText(@"D:\Projects\AoC\2024re\Tests\Input1.txt");
        Assert.Equal(1197984, day1.GetTotalDistance(input));
    }

    [Fact]
    public void AcceptanceTest2()
    {
        Assert.Equal(31, day1.GetSimilarityScore(acceptance));
    }

    [Fact]
    public void Part2()
    {
        string input = File.ReadAllText(@"D:\Projects\AoC\2024re\Tests\Input1.txt");
        Assert.Equal(23387399, day1.GetSimilarityScore(input));
    }
}
