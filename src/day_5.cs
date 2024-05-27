using System.Text.RegularExpressions;

namespace AOC
{
    class Day5
    {
        static List<char>[] ParseCrates(string[] data)
        {
            string[] a = data.TakeWhile((item) => !item.Contains('1')).ToArray();
            string b = data.SkipWhile((item) => !item.Contains('1')).First();

            // parse crates

            int len = b.Replace(" ", "").Length;
            List<char>[] stacks = new List<char>[len];

            int offset = 1;
            for (int j = 0; j < len; j++)
            {
                stacks[j] = [];
                for (int i = a.Length - 1; i > -1; i--)
                {
                    string crate = a[i].Replace('[', ' ').Replace(']', ' ');
                    if (crate[offset] != ' ')
                    {
                        stacks[j].Add(Convert.ToChar(crate[offset]));
                    }
                }
                offset += 4;
            }
            return stacks;

        }
        static int[] ParseProcedure(string[] data)

        {

            string[] a = data.TakeWhile((item) => !item.Contains('1')).ToArray();
            string b = data.SkipWhile((item) => !item.Contains('1')).First();
            string[] c = data.SkipWhile((item, idx) => !item.Contains("move")).ToArray();
            // parse crates



            // parse instructions 
            int[] procedure = new int[c.Length * 3];
            int j = 0;
            for (int i = 0; i < c.Length; i++)
            {
                string[] k = c[i].Replace("move", "").Replace("from", "").Replace("to", "").Split("  ");
                procedure[j] = int.Parse(k[0]);
                procedure[j + 1] = int.Parse(k[1]) - 1;
                procedure[j + 2] = int.Parse(k[2]) - 1;
                j += 3;
            }
            return procedure;


        }
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            List<char>[] c = ParseCrates(data);
            int[] p = ParseProcedure(data);

            for (int i = 0; i < p.Length; i += 3)
            {
                int count = p[i];
                int from = p[i + 1];
                int to = p[i + 2];
                List<char> r = c[from].GetRange(c[from].Count - count, count);
                r.Reverse();
                c[to].AddRange(r);
                c[from].RemoveRange(c[from].Count - count, count);
            }

            string result = c.Aggregate("", (current, item) => current += item[^1]);
            Console.WriteLine("Part One -> " + result);
        }

        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            List<char>[] c = ParseCrates(data);
            int[] p = ParseProcedure(data);

            for (int i = 0; i < p.Length; i += 3)
            {
                int count = p[i];
                int from = p[i + 1];
                int to = p[i + 2];

                c[to].AddRange(c[from].GetRange(c[from].Count - count, count));
                c[from].RemoveRange(c[from].Count - count, count);
            }
            string result = c.Aggregate("", (current, item) => current += item[^1]);

            Console.WriteLine("Part Two -> " + result);

        }

    }
}
