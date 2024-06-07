using System.Numerics;

namespace AOC
{
    class Day17
    {

        static string PosToId(int x, int y)
        {
            return $"<{x},{y}>";
        }
        static string PosToId(int[] pos)
        {
            return $"<{pos[0]},{pos[1]}>";
        }

        public static Dictionary<char, int> directions = new()
            {
                { '<', -1 },
                { '>', 1 }
            };

        static class Rock
        {
            static readonly int[][] r1 = [[2, 0], [3, 0], [4, 0], [5, 0]];
            static readonly int[][] r2 = [[2, 1], [3, 1], [4, 1], [3, 0], [3, 2]];
            static readonly int[][] r3 = [[2, 0], [3, 0], [4, 0], [4, 1], [4, 2]];
            static readonly int[][] r4 = [[2, 0], [2, 1], [2, 2], [2, 3]];
            static readonly int[][] r5 = [[2, 0], [2, 1], [3, 0], [3, 1]];
            public static readonly List<int[][]> rocks = [
                                                                      // #
                                    // .#.          // ..#            // #
                                    // ###          // ..#            // #            // ##
                    // ####         // .#.          // ###            // #            // ##            
                    r1,             r2,             r3,               r4,             r5
                ];
            public static int[][] Create(int idx, int yoffset)
            {
                int n = rocks[idx].Length;
                int[][] rock = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    rock[i] = [rocks[idx][i][0], rocks[idx][i][1] + yoffset];

                }
                return rock;
            }

        }
        public static void Display(HashSet<string> c, int[][] rock)
        {
            int h = rock.Last()[1];
            string str = "\n";
            for (int row = h + 1; row > Math.Max(h - 8, -1); row--)
            {
                str += "|";
                for (int col = 0; col < 7; col++)
                {
                    bool isFalling = rock.Aggregate(false, (ans, e) => ans || (e[0] == col && e[1] == row));
                    if (isFalling) str += " @";
                    else if (c.Contains(PosToId(col, row))) str += " #";
                    else str += " .";

                }
                str += " |\n";

            }
            str += "+---------------+";
            Console.Clear();
            Console.WriteLine(str);
            Thread.Sleep(200);
        }

        public static class State
        {
            public static int p = 0;
            public static int r = 0;
            public static int highest = 0;
            public static int rockCount = 0;
            public static HashSet<string> chamber = [];
            public static void Reset()
            {
                p = 0;
                r = 0;
                highest = 0;
                rockCount = 0;
                chamber = [];
            }
        }
        public static void Simulate(string pattern)
        {

            bool settled = false;
            int[][] curr = Rock.Create(State.r, State.highest + 3);
            while (!settled)
            {
                int d = directions[pattern[State.p]];
                State.p = (State.p + 1) % pattern.Length;

                int[][] copied = new int[curr.Length][];
                for (int k = 0; k < curr.Length; k++)
                {
                    copied[k] = [curr[k][0] + d, curr[k][1]];
                    if (State.chamber.Contains(PosToId(copied[k])) || copied[k][0] < 0 || copied[k][0] > 6) { copied = curr; break; }
                }
                curr = copied;
                bool isSucess = true;
                copied = new int[curr.Length][];
                for (int k = 0; k < curr.Length; k++)
                {
                    copied[k] = [curr[k][0], curr[k][1] - 1];
                    if (State.chamber.Contains(PosToId(copied[k])) || copied[k][1] < 0) { isSucess = false; break; }
                }
                if (isSucess) curr = copied;
                else settled = true;
            }
            State.r = (State.r + 1) % 5;
            State.rockCount++;
            foreach (var pos in curr)
            {
                string id = PosToId(pos[0], pos[1]);
                State.highest = Math.Max(State.highest, pos[1] + 1);
                State.chamber.Add(id);
            }
        }
        public static void PartOne(string mode)
        {
            State.Reset();
            string pattern = Helper.ReadAsString(mode);

            while (State.rockCount < 2022)
            {
                Simulate(pattern);
            }
            Console.WriteLine("Part One -> " + State.highest);

        }

        public static void PartTwo(string mode)
        {
            State.Reset();
            string pattern = Helper.ReadAsString(mode);
            ulong brr = 1000000000000;
            ulong remainingCount = 0;
            ulong computedHeight = 0;

            Dictionary<string, int[]> states = [];

            while ((ulong)State.rockCount < brr)
            {

                bool isRepeating = true;

                for (int i = 0; i < 7; i++)
                {
                    string id = PosToId(i, State.highest - 2);
                    if (!State.chamber.Contains(id)) { isRepeating = false; break; }

                }
                if (isRepeating)
                {
                    string s = PosToId(State.r, State.p);
                    if (states.ContainsKey(s))
                    {
                        ulong prc = (ulong)states[s][0];
                        ulong ph = (ulong)states[s][1];
                        ulong rc = (ulong)State.rockCount;
                        ulong hh = (ulong)State.highest;
                        ulong n = (brr - prc) / (rc - prc);
                        remainingCount = brr - n * (rc - prc);
                        computedHeight = ph + n * (hh - ph) + 1 - hh - ph;
                        break;
                    }
                    else
                        states[s] = [State.rockCount, State.highest];

                }
                Simulate(pattern);
            }

            int k = (int)remainingCount + 1;
            State.rockCount = 0;
            while (State.rockCount < k)
            {
                Simulate(pattern);
            }
            long result = State.highest + (long)computedHeight;
            Console.WriteLine("Part Two -> " + result);
        }

    }
}
