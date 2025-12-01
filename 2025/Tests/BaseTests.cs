namespace Tests;

using Advent2025;

public abstract class BaseTests<T> where T : Solver,new()
{
    private readonly T solver = new();
    protected abstract string AcceptanceInput1 { get; }
    protected abstract string AcceptanceInput2 { get; }
    protected abstract object AcceptencePart1 { get; }
    protected abstract object AcceptencePart2 { get; }
    protected abstract object ExpectedPart1 { get; }
    protected abstract object ExpectedPart2 { get; }
    protected abstract int Day { get; }

    private string GetInput()
    {
        var path = $@"D:\Projects\AoC\2025\Tests\Input{Day}.txt";
        return File.ReadAllText(path);
    }

    [Fact]
    public void AcceptanceTest1()
    {
        Assert.Equal(AcceptencePart1, solver.Part1(AcceptanceInput1));
    }

    [Fact]
    public void Part1()
    {
        Assert.Equal(ExpectedPart1, solver.Part1(GetInput()));
    }

    [Fact]
    public void AcceptanceTest2()
    {
        var input = AcceptanceInput2 ?? AcceptanceInput1;
        Assert.Equal(AcceptencePart2, solver.Part2(input));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(ExpectedPart2, solver.Part2(GetInput()));
    }
}
