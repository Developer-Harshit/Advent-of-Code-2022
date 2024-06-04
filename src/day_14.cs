namespace AOC
{
    class Day14
    {
        static readonly string rock = "██";
        static readonly string sand = "░░";
        static readonly string falling = "[]";
        static readonly string space = "  ";

        static string VectorToString(int[] vect)
        {
            return $"<{vect[0]},{vect[1]}>";
        }
        static Tuple<Dictionary<string, string>, int[]> MakeGrid(string mode)
        {
            // minx , miny ,maxx ,maxy
            int[] bounds = [int.MaxValue, int.MaxValue, 0, 0];

            string[] data = Helper.ReadAsArray(mode);

            Dictionary<string, string> d = [];
            for (int i = 0; i < data.Length; i++)
            {

                string[] k = data[i].Replace(" ", "").Split("->");

                int[]? prev = null;
                foreach (string v in k)
                {
                    int[] curr = Array.ConvertAll(v.Split(','), int.Parse);
                    bounds[0] = Math.Min(curr[0], bounds[0]);
                    bounds[1] = Math.Min(curr[1], bounds[1]);
                    bounds[2] = Math.Max(curr[0], bounds[2]);
                    bounds[3] = Math.Max(curr[1], bounds[3]);
                    if (prev != null)
                    {

                        int[] m = [Math.Max(prev[0], curr[0]), Math.Max(prev[1], curr[1])];
                        int[] n = [Math.Min(prev[0], curr[0]), Math.Min(prev[1], curr[1])];
                        for (int row = n[1]; row <= m[1]; row++)
                        {
                            for (int col = n[0]; col <= m[0]; col++)
                            {
                                int[] ele = [col, row];
                                string id = VectorToString(ele);
                                d[id] = rock;
                            }
                        }
                    }
                    prev = curr;
                }
            }
            return new(d, bounds);
        }
        static void Display(Dictionary<string, string> d, int[] bounds, int[] s, bool p2 = true)
        {


            int offset = p2 ? 10 : 1;

            string lineBreak = ' ' + new String('-', (bounds[2] - bounds[0] + 1 + offset * 2) * 2) + '\n';
            string str = lineBreak;
            string curr = VectorToString(s);
            for (int j = 0; j < bounds[3] + 2; j++)
            {
                str += '|';
                for (int i = bounds[0] - offset; i < bounds[2] + 1 + offset; i++)
                {


                    string id = VectorToString([i, j]);
                    if (id == curr) str += falling;
                    else if (d.ContainsKey(id)) str += d[id];
                    else str += space;
                }
                str += '|';
                str += "\n";

            }
            if (p2) str += "......." + new String(rock[0], (bounds[2] - bounds[0] + 1 + offset * 2) * 2 - 12) + ".......\n";
            else str += lineBreak;



            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine(str);

        }


        public static void PartOne(string mode)
        {


            (var cave, var bounds) = MakeGrid(mode);
            int[] source = [500, 0];
            int[] s = [.. source];


            (int w, int h) = (bounds[2] + 1, bounds[3] + 1);
            int sandCount = 0;
            string id;


            while (true)
            {
                if (s[1] > h) break;
                if (mode == "debug")
                {
                    Display(cave, bounds, s);
                    Console.WriteLine($"Sand Count -> {sandCount}");
                }
                // try falling down
                id = VectorToString([s[0], s[1] + 1]);
                if (!cave.ContainsKey(id))
                {
                    s[1]++;
                    continue;
                }

                // try falling down left 
                id = VectorToString([s[0] - 1, s[1] + 1]);
                if (!cave.ContainsKey(id))
                {
                    s[1]++;
                    s[0]--;
                    continue;
                }

                // try right
                id = VectorToString([s[0] + 1, s[1] + 1]);
                if (!cave.ContainsKey(id))
                {
                    s[1]++;
                    s[0]++;
                    continue;
                }

                // else sand is stable
                id = VectorToString(s);
                cave[id] = sand;
                s = [.. source];
                sandCount++;




            }
            Display(cave, bounds, s);
            Console.WriteLine("Part One -> " + sandCount);

        }
        public static void PartTwo(string mode)
        {

            (var cave, var bounds) = MakeGrid(mode);
            int[] source = [500, 0];
            int[] s = [.. source];


            (int w, int h) = (bounds[2] + 1, bounds[3] + 1);
            int sandCount = 0;
            string id;



            while (true)
            {
                if (mode == "debug")
                {
                    Display(cave, bounds, s);
                    Console.WriteLine($"Sand Count -> {sandCount}");
                }
                // try falling down
                id = VectorToString([s[0], s[1] + 1]);

                if (!cave.ContainsKey(id) && s[1] < h)
                {
                    s[1]++;
                    continue;
                }

                // try falling down left 
                id = VectorToString([s[0] - 1, s[1] + 1]);
                if (!cave.ContainsKey(id) && s[1] < h)
                {
                    s[1]++;
                    s[0]--;
                    continue;
                }

                // try right
                id = VectorToString([s[0] + 1, s[1] + 1]);
                if (!cave.ContainsKey(id) && s[1] < h)
                {

                    s[1]++;
                    s[0]++;
                    continue;
                }

                // else sand is stable
                bool willEnd = false;
                if (s[0] == source[0] && s[1] == source[1]) willEnd = true;

                id = VectorToString(s);
                cave[id] = sand;
                s = [.. source];
                sandCount++;

                if (willEnd) break;




            }
            Display(cave, bounds, s);
            Console.WriteLine("Part Two -> " + sandCount);

        }

    }
}
