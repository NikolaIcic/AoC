namespace Advent2025
{
    public class Day6 : Solver
    {
        public override object Part1(string input) => Solve(ReadHuman(input));
        public override object Part2(string input) => Solve(ReadCephalopod(input));
        private static long Solve(List<(ICollection<int> values, bool op)> problems)
        {
            long total = 0;
            foreach (var p in problems)
            {
                if (p.op)
                    total += p.values.Aggregate((long)1, (acc, x) => acc * x);
                else
                    total += p.values.Aggregate((long)0, (acc, x) => acc + x);
            }

            return total;
        }
        private static List<(ICollection<int> values, bool op)> ReadHuman(string input)
        {
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            List<(ICollection<int> values, bool op)> problems = [];
            var lastRow = rows[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lastRow.Length; i++)
            {
                problems.Add(new()
                {
                    op = lastRow[i] == "*",
                    values = []
                });
            }
            for (int i = 0; i < rows.Length - 1; i++)
            {
                var values = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < values.Length; j++)
                {
                    problems[j].values.Add(int.Parse(values[j]));
                }
            }
            return problems;
        }
        private static List<(ICollection<int> values, bool op)> ReadCephalopod(string input)
        {
            List<(ICollection<int> values, bool op)> problems = [];
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var lastRow = rows[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lastRow.Length; i++)
            {
                problems.Add(new()
                {
                    op = lastRow[i] == "*",
                    values = []
                });
            }

            int cols = rows.Max(l => l.Length);

            ICollection<int> vals = [];
            int problemIndex = 0;
            for(int i = 0; i < cols; i++)
            {
                if (IsBlankCol(i, rows))
                {
                    foreach(var v in vals)
                        problems[problemIndex].values.Add(v);
                    problemIndex++;
                    vals = [];
                    continue;
                }
                string num = "";
                for(int j=0;j<rows.Length - 1; j++)
                {
                    if (rows[j][i] != ' ')
                        num += rows[j][i];
                }
                vals.Add(int.Parse(num));
            }
            foreach (var v in vals)
                problems[problemIndex].values.Add(v);

            return problems;
        }

        private static bool IsBlankCol(int i, string[] rows)
        {
            for(int j=0; j<rows.Length; j++)
            {
                if (rows[j].Length <= i)
                    continue;
                if (rows[j][i] != ' ')
                    return false;
            }
                
            return true;
        }
    }
}
