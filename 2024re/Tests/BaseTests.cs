namespace Tests;

using Advent2024;

public class BaseTests
{
    private BaseClass baseClass = new();
    private const string acceptance = "";
    [Fact]
    public void AcceptanceTest1()
    {
        Assert.Equal(0, baseClass.Part1(acceptance));
    }

    [Fact]
    public void Part1()
    {

        string input = File.ReadAllText(@"D:\Projects\AoC\2024re\Tests\Input1.txt");
        Assert.Equal(0, baseClass.Part1(input));
    }

    [Fact]
    public void AcceptanceTest2()
    {
        Assert.Equal(0, baseClass.Part2(acceptance));
    }

    [Fact]
    public void Part2()
    {
        string input = File.ReadAllText(@"D:\Projects\AoC\2024re\Tests\Input1.txt");
        Assert.Equal(0, baseClass.Part2(input));
    }
}
