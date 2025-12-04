using System.Numerics;

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
                List<Vector2> toRemove = [];
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

        private static HashSet<Vector2> MakeMap(string input)
        {
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            HashSet<Vector2> rolls = [];
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '@')
                        rolls.Add(new Vector2(j, i));
            return rolls;
        }

        private static bool RollIsAccessible(Vector2 roll, HashSet<Vector2> map)
        {
            int adjacent = 0;

            ReadOnlySpan<(int dx, int dy)> dirs = [
                (1, 0), (-1, 0), (0, 1), (0, -1),
                (-1, 1), (-1, -1), (1, -1), (1, 1)
            ];

            foreach (var (dx, dy) in dirs)
                if (map.Contains(new Vector2(roll.X + dx, roll.Y + dy)))
                    adjacent++;

            return adjacent < 4;
        }
    }
}
