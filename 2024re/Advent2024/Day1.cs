namespace Advent2024;

public class Day1
{
    public int GetTotalDistance(string input)
    {
        var (l1, l2) = ReadLists(input);
        l1.Sort();
        l2.Sort();
        int sum = 0;
        for (int i = 0; i < l1.Count; i++)
            sum += Math.Abs(l2[i] - l1[i]);
        return sum;
    }

    public int GetSimilarityScore(string input)
    {
        var (l1, l2) = ReadLists(input);
        int sum = 0;
        foreach (int el in l1)
            sum += el * l2.Where(x => x == el).Count();
        return sum;
    }

    private (List<int> l1, List<int> l2) ReadLists(string input)
    {
        var rows = input.Split("\r\n");
        List<int> l1 = new List<int>();
        List<int> l2 = new List<int>();
        foreach (string row in rows)
        {
            var numbs = row.Split(' ');
            l1.Add(int.Parse(numbs[0]));
            l2.Add(int.Parse(numbs[numbs.Length - 1]));
        }

        if (l1.Count != l2.Count)
            throw new ArgumentException("Lists do not match");

        return (l1, l2);
    }
}
