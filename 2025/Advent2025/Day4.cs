namespace Advent2025
{
    public class Day4 : Solver
    {
        public override object Part1(string input) => Solve(input);
        public override object Part2(string input) => Solve2(input);

        private static int Solve(string input)
        {
            var map = MakeMap(input);
            int count = 0;
            foreach (var item in map)
                if (RollIsAccessible(item, map))
                    count++;
            return count;
        }

        private static int Solve2(string input)
        {
            var map = MakeMap(input);
            int count = 0;

            while (true)
            {
                List<(int x,int y)> toRemove = [];
                foreach (var item in map)
                    if (RollIsAccessible(item, map))
                        toRemove.Add(item);

                if (toRemove.Count == 0)
                    break;

                foreach (var r in toRemove)
                    map.Remove(r);
                count += toRemove.Count;
            }

            return count;
        }

        private static HashSet<(int x,int y)> MakeMap(string input)
        {
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            HashSet<(int x,int y)> rolls = [];
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '@')
                        rolls.Add(new (j,i));
            return rolls;
        }

        private static bool RollIsAccessible((int x,int y) roll, HashSet<(int x,int y)> map)
        {
            int adjacent = 0;

            ReadOnlySpan<(int dx, int dy)> dirs = [
                (1, 0), (-1, 0), (0, 1), (0, -1),
                (-1, 1), (-1, -1), (1, -1), (1, 1)
            ];

            foreach (var (dx, dy) in dirs)
                if (map.Contains(new (roll.x + dx, roll.y + dy)))
                    adjacent++;

            return adjacent < 4;
        }
    }
}
