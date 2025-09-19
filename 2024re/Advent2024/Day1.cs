namespace Advent2024;

public class Day1
{
    public int GetTotalDistance(string input)
    {
        var (l1, l2) = ReadLists(input);

        l1.Sort();
        l2.Sort();

        return l1.Zip(l2).Sum(p => Math.Abs(p.First - p.Second));
    }

    public int GetSimilarityScore(string input)
    {
        var (l1, l2) = ReadLists(input);

        return l1.Sum(el => el * l2.Count(x => x == el));
    }

    private (List<int> l1, List<int> l2) ReadLists(string input)
    {
        var rows = input.Split("\r\n");
        
        var l1 = rows.Select(row => int.Parse(row.Split(' ')[0])).ToList();
        var l2 = rows.Select(row => int.Parse(row.Split(' ').Last())).ToList();

        if (l1.Count != l2.Count)
            throw new ArgumentException("Lists do not match");

        return (l1, l2);
    }
}
