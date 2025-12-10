namespace Advent2025
{
    public class Day10 : Solver
    {
        public override object Part1(string input) => Solve(input);
        public override object Part2(string input) => Solve2(input);
        private static int Solve(string input)
        {
            var machines = ReadMachines(input);
            int total = 0;

            foreach (var m in machines)
            {
                int target = ToIntMask(m.Expected);
                var buttonMasks = m.ButtonGroups.Select(ButtonsToIntMask).ToList();
                int presses = FindMinPressessBFS(target, buttonMasks);
                total += presses;
            }

            return total;
        }
        public static long Solve2(string input)
        {
            var machines = ReadMachines(input);
            long total = 0;

            return total;
        }
        private static List<Machine> ReadMachines(string input)
        {
            List<Machine> list = [];
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
            {
                var parts = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var lights = parts[0][1..^1].Select(x => x == '#').ToArray();
                var batteries = parts[1..^1].Select(x => x[1..^1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray()).ToList();
                var jolts = parts[^1][1..^1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                list.Add(new Machine(lights, batteries, jolts));
            }
            return list;
        }
        private class Machine(bool[] lights, List<int[]> buttons, int[] jolts)
        {
            public readonly bool[] Lights = new bool[lights.Length];
            public readonly bool[] Expected = lights;
            public readonly List<int[]> ButtonGroups = buttons;
            public readonly int[] Joltages = jolts;
        }
        private static int ToIntMask(bool[] arr)
        {
            int m = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i])
                    m |= 1 << i;
            return m;
        }
        private static int ButtonsToIntMask(int[] buttons)
        {
            int m = 0;
            foreach (var btnIndex in buttons)
                m |= 1 << btnIndex;
            return m;
        }
        private static int FindMinPressessBFS(int targetMask, List<int> buttonMasks)
        {
            if (targetMask == 0)
                return 0;

            var visited = new Dictionary<int, int>();
            var queue = new Queue<int>();

            visited[0] = 0;
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == targetMask)
                    return visited[current];   
                int count = visited[current];

                foreach (var button in buttonMasks)
                {
                    int next = current ^ button;
                    if (!visited.ContainsKey(next))
                    {
                        visited[next] = count + 1;
                        queue.Enqueue(next);
                    }
                }
            }
            return 0;
        }
    }
}
