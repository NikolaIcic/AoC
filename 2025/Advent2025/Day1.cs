namespace Advent2025
{
    public class Day1 : Solver
    {
        public override object Part1(string input) => CountZeroPointOccurences(50, input);
        public override object Part2(string input) => CountZeroPointClicks(50, input);

        private static int CountZeroPointOccurences(int dial, string input)
        {
            var rows = input.Split("\r\n");
            int count = 0;
            foreach (string row in rows)
            {
                int turn = int.Parse(row[1..]);
                dial = row[0] == 'L' ?
                dial = (dial - turn % 100 + 100) % 100 :
                dial = (dial + turn) % 100;
                if (dial == 0)
                    count++;
            }
            return count;
        }

        private static int CountZeroPointClicks(int dial, string input)
        {
            var rows = input.Split("\r\n");
            int count = 0;

            foreach (var row in rows)
            {
                int turn = int.Parse(row[1..]);
                int step = (row[0] == 'L') ? -1 : 1;

                for (int i = 0; i < turn; i++)
                {
                    dial += step;

                    if (dial < 0) dial = 99;
                    else if (dial > 99) dial = 0;

                    if (dial == 0)
                        count++;
                }
            }

            return count;
        }

    }
}
