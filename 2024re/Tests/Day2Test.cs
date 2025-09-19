namespace Tests;

using Advent2024;

public class Day2Tests
{
    private Day2 day2 = new Day2();
    private const string acceptance = "7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9";
    [Fact]
    public void AcceptanceTest1()
    {
        Assert.Equal(2, day2.Part1(acceptance));
    }

    [Fact]
    public void Part1()
    {

        string input = File.ReadAllText(@"D:\Projects\AoC\2024re\Tests\Input2.txt");
        Assert.Equal(371, day2.Part1(input));
    }

    [Fact]
    public void AcceptanceTest2()
    {
        Assert.Equal(4, day2.Part2(acceptance));
    }

    [Fact]
    public void Part2()
    {
        string input = File.ReadAllText(@"D:\Projects\AoC\2024re\Tests\Input2.txt");
        Assert.Equal(426, day2.Part2(input));
    }
}
