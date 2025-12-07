namespace Advent2025
{
    public class Day7 : Solver
    {
        public override object Part1(string input) => Solve(ReadMap(input));
        public override object Part2(string input) => Solve2(ReadMap(input));
        private static int Solve((HashSet<(int x, int y)> splitters, int beam, int rowlen) lab)
        {
            HashSet<int> beams = [];
            beams.Add(lab.beam);
            var splits = 0;
            for (int i = 0; i < lab.rowlen; i++)
            {
                HashSet<int> toSplit = [];
                foreach (var b in beams)
                    if (lab.splitters.Contains((b, i)))
                    {
                        splits++;
                        toSplit.Add(b);
                        beams.Remove(b);
                    }
                foreach (var ts in toSplit)
                {
                    beams.Add(ts + 1);
                    beams.Add(ts - 1);
                }
            }
            return splits;
        }

        private static long Solve2((HashSet<(int x, int y)> splitters, int b, int rowlen) lab)
        {
            (int x, int y) beam = (lab.b, 0);
            Dictionary<(int x, int y), long> memo = [];
            return QuantumPossibilities(beam, lab.splitters, lab.rowlen, memo);
        }

        private static long QuantumPossibilities((int x, int y) beam, HashSet<(int x, int y)> splitters, int rowlen, Dictionary<(int x, int y), long> memo)
        {
            if (memo.TryGetValue(beam, out long val))
                return val;
            long result;
            if (beam.y >= rowlen - 1)
                return 1;
            else if (splitters.Contains(beam))
            {
                result = QuantumPossibilities((beam.x + 1, beam.y + 1), splitters, rowlen, memo)
                    + QuantumPossibilities((beam.x - 1, beam.y + 1), splitters, rowlen, memo);
            }
            else
                result = QuantumPossibilities((beam.x, beam.y + 1), splitters, rowlen, memo);
            memo[beam] = result;
            return result;
        }
        private static (HashSet<(int x, int y)> splitters, int beam, int rowlen) ReadMap(string input)
        {
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var beam = 0;
            HashSet<(int x, int y)> splitters = [];
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] == 'S') beam = j;
                    else if (rows[i][j] == '^') splitters.Add((j, i));
                }
            return (splitters, beam, rows.Length);
        }
    }
}
