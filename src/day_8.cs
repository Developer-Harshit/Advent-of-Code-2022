using System.Reflection;

namespace AOC
{
    class Day8
    {
        public static int[,] offsets = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int width = data[0].Length;
            int height = data.Length;

            int result = (width + height - 2) * 2; // edge count
            for (int j = 1; j < height - 1; j++)
            {
                for (int i = 1; i < width - 1; i++)
                {
                    int curr = int.Parse(data[j][i] + "");
                    for (int k = 0; k < 4; k++)
                    {
                        int r = 1;
                        int x = offsets[k, 0] + i;
                        int y = offsets[k, 1] + j;
                        bool isVisible = true;
                        while (Helper.WithinBounds(x, y, width, height))
                        {
                            int ele = int.Parse(data[y][x] + "");
                            if (curr <= ele)
                            {
                                isVisible = false;
                                break;
                            }
                            r += 1;
                            x = offsets[k, 0] * r + i;
                            y = offsets[k, 1] * r + j;
                        }

                        if (isVisible)
                        {
                            result += 1;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Part One -> " + result);

        }
        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);

            int width = data[0].Length;
            int height = data.Length;

            int bestScore = 1;
            for (int j = 1; j < height - 1; j++)
            {
                for (int i = 1; i < width - 1; i++)
                {

                    int score = 1;
                    int curr = int.Parse(data[j][i] + "");
                    for (int k = 0; k < 4; k++)
                    {
                        int r = 1;
                        int x = offsets[k, 0] + i;
                        int y = offsets[k, 1] + j;

                        int count = 0;
                        while (Helper.WithinBounds(x, y, width, height))
                        {
                            int ele = int.Parse(data[y][x] + "");
                            count += 1;
                            if (curr <= ele) break;

                            r += 1;
                            x = offsets[k, 0] * r + i;
                            y = offsets[k, 1] * r + j;
                        }
                        score *= count;
                    }
                    bestScore = Math.Max(bestScore, score);
                }
            }
            Console.WriteLine("Part Two -> " + bestScore);

        }

    }
}
