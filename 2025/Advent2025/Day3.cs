using System.Numerics;

namespace Advent2025
{
    public class Day3 : Solver
    {
        public override object Part1(string input) => input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Sum(x => FindBankJoltage(x, 2));
        public override object Part2(string input) => input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Sum(x => FindBankJoltage(x, 12));

        private static double FindBankJoltage(string bank, int batteries)
        {
            int[] indexes = new int[batteries];
            indexes[0] = 0;

            for (int i = 0; i < bank.Length - batteries + 1; i++)
            {
                if (bank[i] > bank[indexes[0]])
                    indexes[0] = i;
                if (bank[i] == '9')
                    break;
            }
            for (int i = 1; i < indexes.Length; i++)
            {
                indexes[i] = indexes[i - 1] + 1;
                for (int j = indexes[i] + 1; j < bank.Length - batteries + i + 1; j++)
                {
                    if (bank[j] > bank[indexes[i]])
                        indexes[i] = j;
                    if (bank[j] == '9')
                        break;
                }
            }

            double sum = 0;
            for (int i = 0; i < indexes.Length; i++)
                sum += int.Parse(bank[indexes[i]].ToString()) * Math.Pow(10, indexes.Length - i - 1);
            return sum;
        }
    }
}
