readonly record struct Vector3(int x, int y, int z);
record Edge(Vector3 A, Vector3 B, long Distance);

namespace Advent2025
{
    public class Day8 : Solver
    {
        public override object Part1(string input) => Solve(input);
        public override object Part2(string input) => Solve2(input);
        private static int Solve(string input)
        {
            var boxes = MapBoxes(input).ToList();
            var edges = FindAllEdges(boxes);
            edges.Sort((a, b) => a.Distance.CompareTo(b.Distance));

            var dsu = new DSU(boxes);
            int connections = boxes.Count == 20 ? 10 : 1000;
            for (int i = 0; i < connections; i++) 
                dsu.Union(edges[i].A, edges[i].B);
            var sizes = dsu.GetAllSizes();
            sizes.Sort((a, b) => b - a);
            return sizes[0] * sizes[1] * sizes[2];
        }

        private static int Solve2(string input)
        {
            var boxes = MapBoxes(input).ToList();
            var edges = FindAllEdges(boxes);
            edges.Sort((a, b) => a.Distance.CompareTo(b.Distance));

            var dsu = new DSU(boxes);
            var unions = 0;
            foreach (var e in edges)
                if (dsu.Union(e.A, e.B))
                {
                    unions++;
                    if (unions == boxes.Count - 1)
                        return e.A.x * e.B.x;
                }

            throw new ArgumentException("Could not join all boxes in a union");
        }
        private static HashSet<Vector3> MapBoxes(string input)
        {
            HashSet<Vector3> boxes = [];
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
            {
                var cords = row.Split(',', StringSplitOptions.RemoveEmptyEntries);
                boxes.Add(new(int.Parse(cords[0]), int.Parse(cords[1]), int.Parse(cords[2])));
            }
            return boxes;
        }
        private static List<Edge> FindAllEdges(List<Vector3> boxes)
        {
            List<Edge> edges = [];

            for (int i = 0; i < boxes.Count - 1; i++)
            {
                var a = boxes[i];
                for (int j = i + 1; j < boxes.Count; j++)
                {
                    var b = boxes[j];
                    long dx = (long)a.x - b.x;
                    long dy = (long)a.y - b.y;
                    long dz = (long)a.z - b.z;
                    edges.Add(new Edge(a, b, dx * dx + dy * dy + dz * dz));
                }
            }
            return edges;
        }
        private class DSU
        {
            private readonly Dictionary<Vector3, Vector3> parents = [];
            private readonly Dictionary<Vector3, int> sizes = [];
            public DSU(IEnumerable<Vector3> boxes)
            {
                foreach (var box in boxes)
                {
                    parents.Add(box, box);
                    sizes.Add(box, 1);
                }
            }
            public Vector3 Find(Vector3 x)
            {
                if (!parents[x].Equals(x))
                    parents[x] = Find(parents[x]);
                return parents[x];
            }
            public bool Union(Vector3 a, Vector3 b)
            {
                a = Find(a);
                b = Find(b);
                if (a.Equals(b))
                    return false;

                if (sizes[a] < sizes[b])
                    (a, b) = (b, a);

                parents[b] = a;
                sizes[a] += sizes[b];
                sizes.Remove(b);

                return true;
            }
            public List<int> GetAllSizes()
            {
                return [.. sizes.Values];
            }
        }
    }
}
