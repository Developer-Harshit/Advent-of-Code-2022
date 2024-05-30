using System.Net;
using System.Linq;
namespace AOC
{


    class Day9
    {

        public static Dictionary<char, int[]> offsets = new()
        {
            {'R',[1, 0]},{'L',[-1, 0]},{'U',[0, -1]},{'D',[0, 1]},
        };

        public static double Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        public static bool Contains(List<int[]> p, int[] item)
        {

            foreach (int[] other in p)
            {
                if (other[0] == item[0] && other[1] == item[1]) return true;

            }
            return false;

        }
        public static void Display(int[][] knots)
        {

            // int w = 6;
            // int h = 5;
            int w = 26;
            int h = 21;

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    int k = Array.FindIndex(knots, (coord) => coord[0] == i && coord[1] == j);
                    if (k == -1) Console.Write(".");
                    else Console.Write("" + k);


                }
                Console.WriteLine();
            }
        }


        public static bool IsTouching(int[] first, int[] second)
        {
            int x = Math.Abs(first[0] - second[0]);
            int y = Math.Abs(first[1] - second[1]);

            return (x == 1 && y == 1) || (x == 0 && y == 0) || (x + y == 1);
        }
        public static int[] FindDelta(int[] head, int[] tail)
        {
            int x = head[0] - tail[0];
            int y = head[1] - tail[1];
            if (x == 0 && Math.Abs(y) == 1 || y == 0 && Math.Abs(x) == 1) return [x, y];
            return [Math.Sign(x), Math.Sign(y)];


        }

        public static int Compute(string mode, int knotCount)
        {
            // int sx = 11;
            // int sy = 15;
            // int sx = 0;
            // int sy = 4;
            int sx = 0;
            int sy = 0;

            string[] data = Helper.ReadAsArray(mode);
            int[][] knots = new int[knotCount][];
            for (int i = 0; i < knotCount; i++)
            {
                knots[i] = [sx, sy];

            }
            List<int[]> path = [];
            foreach (string motion in data)
            {
                int[] offset = offsets[motion[0]];
                int steps = int.Parse(motion[2..]);

                for (int _ = 0; _ < steps; _++)
                {

                    knots[0][0] += offset[0];
                    knots[0][1] += offset[1];

                    for (int k = 1; k < knotCount; k++)
                    {
                        bool touching = IsTouching(knots[k], knots[k - 1]);
                        if (touching) break;
                        int[] delta = FindDelta(knots[k - 1], knots[k]);
                        knots[k][0] += delta[0];
                        knots[k][1] += delta[1];

                    }
                    int[] ele = [.. knots[knotCount - 1]];
                    if (!Contains(path, ele)) path.Add(ele);


                }
            }



            return path.Count;
        }

        public static void PartOne(string mode)

        {

            int result = Compute(mode, 2);
            Console.WriteLine("Part One -> " + result);
        }

        public static void PartTwo(string mode)
        {

            int result = Compute(mode, 10);
            Console.WriteLine("Part One -> " + result);

        }

    }
}

