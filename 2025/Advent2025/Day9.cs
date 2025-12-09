namespace Advent2025
{
    public class Day9 : Solver
    {
        public override object Part1(string input) => Solve(input);
        public override object Part2(string input) => Solve2(input);
        private static long Solve(string input)
        {
            var tiles = ReadTiles(input);

            long maxArea = 0;

            for (int i = 0; i < tiles.Length; i++)
                for (int j = i + 1; j < tiles.Length; j++)
                {
                    long area = tiles[i].RectArea(tiles[j]);
                    maxArea = Math.Max(maxArea, area);
                }
            return maxArea;
        }
        private static long Solve2(string input)
        {
            var tiles = ReadTiles(input);
            var polygon = new Polygon(tiles);
            long maxArea = 0;

            for (int i = 0; i < tiles.Length; i++)
            {
                var p1 = tiles[i];

                for (int j = i + 1; j < tiles.Length; j++)
                {
                    var p2 = tiles[j];

                    double x1 = Math.Min(p1.X, p2.X) + 0.5;
                    double x2 = Math.Max(p1.X, p2.X) - 0.5;
                    double y1 = Math.Min(p1.Y, p2.Y) + 0.5;
                    double y2 = Math.Max(p1.Y, p2.Y) - 0.5;

                    var rect = new Polygon(
                    [
                        new Point(x1, y1),
                        new Point(x2, y1),
                        new Point(x2, y2),
                        new Point(x1, y2)
                    ]);

                    if (!rect.Edges.Any(e => polygon.Intersects(e)))
                    {
                        long area = p1.RectArea(p2);
                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }

            return maxArea;
        }
        private static Point[] ReadTiles(string input)
        {
            var rows = input.Split("\r\n");
            return [.. rows.Select(row =>
            {
                var parts = row.Split(',');
                return new Point(int.Parse(parts[0]), int.Parse(parts[1]));
            })];
        }
        private class Point(double x, double y)
        {
            public double X { get; } = x;
            public double Y { get; } = y;

            public long RectArea(Point that)
            {
                long width = (long)Math.Abs(X - that.X) + 1;
                long height = (long)Math.Abs(Y - that.Y) + 1;
                return width * height;
            }
        }

        private class Edge
        {
            public bool Horizontal { get; }
            public Point P1 { get; }
            public Point P2 { get; }

            public Edge(Point p1, Point p2)
            {
                Horizontal = p1.Y == p2.Y;
                if (Horizontal)
                {
                    P1 = p1.X < p2.X ? p1 : p2;
                    P2 = p1.X < p2.X ? p2 : p1;
                }
                else
                {
                    P1 = p1.Y < p2.Y ? p1 : p2;
                    P2 = p1.Y < p2.Y ? p2 : p1;
                }
            }

            public bool Intersects(Edge edge)
            {
                if (Horizontal == edge.Horizontal)
                    return false;

                var horizontal = Horizontal ? this : edge;
                var vertical = Horizontal ? edge : this;

                return vertical.P1.X > horizontal.P1.X && vertical.P1.X < horizontal.P2.X &&
                       horizontal.P1.Y > vertical.P1.Y && horizontal.P1.Y < vertical.P2.Y;
            }
        }

        private class Polygon
        {
            public Point[] Points { get; }
            public Edge[] Edges { get; }

            public Polygon(Point[] points)
            {
                Points = points;
                Edges = new Edge[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    var next = points[(i + 1) % points.Length];
                    Edges[i] = new Edge(points[i], next);
                }
            }
            public bool Intersects(Edge edge) => Edges.Any(e => e.Intersects(edge));
        }
    }
}
