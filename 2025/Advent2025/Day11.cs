namespace Advent2025
{
    public class Day11 : Solver
    {
        public override object Part1(string input) => Solve(input);
        public override object Part2(string input) => Solve2(input);

        public static int Solve(string input)
        {
            var nodes = ReadNodes(input);
            return DFS(nodes["you"], nodes["out"], []);
        }
        public static long Solve2(string input)
        {
            var nodes = ReadNodes(input);
            return DFS_Conditional(nodes["svr"], nodes["out"], nodes["dac"], nodes["fft"], false, false, []);
        }
        private static Dictionary<string, Node> ReadNodes(string input)
        {
            var dict = new Dictionary<string, Node>();
            Node GetOrCreate(string name)
            {
                if (!dict.TryGetValue(name, out var n))
                    dict[name] = n = new Node { Name = name };
                return n;
            }

            foreach (var row in input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var parentName = parts[0][0..^1];

                var parent = GetOrCreate(parentName);
                foreach (var childName in parts[1..])
                    parent.Children.Add(GetOrCreate(childName));
            }

            return dict;
        }

        private class Node
        {
            public string Name { get; set; } = "";
            public List<Node> Children { get; set; } = [];
        }

        private static int DFS(Node node, Node target, Dictionary<Node, int> memo)
        {
            if (node == target)
                return 1;

            if (memo.TryGetValue(node, out int cached))
                return cached;

            int total = 0;
            foreach (var child in node.Children)
                total += DFS(child, target, memo);

            memo[node] = total;
            return total;
        }

        private static long DFS_Conditional(Node node, Node target, Node dac, Node fft, bool visitedDac, bool visitedFft, Dictionary<(Node, bool, bool), long> memo)
        {
            if (node == dac) visitedDac = true;
            if (node == fft) visitedFft = true;

            if (node == target)
                return (visitedDac && visitedFft) ? 1 : 0;

            var key = (node, visitedDac, visitedFft);
            if (memo.TryGetValue(key, out long cached))
                return cached;

            long total = 0;
            foreach (var child in node.Children)
                total += DFS_Conditional(child, target, dac, fft, visitedDac, visitedFft, memo);

            memo[key] = total;
            return total;
        }
    }
}
