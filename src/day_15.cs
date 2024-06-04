namespace AOC
{
    class Day15
    {
        public static int[] ParseRow(string row)
        {
            string k = row.Replace("Sensor at x=", "").Replace(" y=", "").Replace(": closest beacon is at x=", ",").Replace(" ", "") + ",0";
            return Array.ConvertAll(k.Split(','), int.Parse);

        }
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int[][] sbPairs = new int[data.Length][];
            int[] bx = [int.MaxValue, 0];
            int maxDist = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int[] c = ParseRow(data[i]);
                int dist = Math.Abs(c[0] - c[2]) + Math.Abs(c[1] - c[3]); // manhattan distance
                c[4] = dist;
                sbPairs[i] = c;

                maxDist = Math.Max(dist, maxDist);
                bx[0] = Math.Min(c[0], bx[0]);
                bx[0] = Math.Min(c[2], bx[0]);
                bx[1] = Math.Max(c[0], bx[1]);
                bx[1] = Math.Max(c[2], bx[1]);
            }
            bx[0] -= maxDist * 2;
            bx[1] += maxDist * 2;

            int counter = 0;
            int j = mode == "debug" ? 10 : 2000000;
            for (int i = bx[0]; i <= bx[1]; i++)
            {

                bool cannotContain = false;
                foreach (int[] sb in sbPairs)
                {
                    if (i == sb[2] && j == sb[3]) { cannotContain = false; break; }
                    int dist = Math.Abs(sb[0] - i) + Math.Abs(sb[1] - j);
                    if (dist <= sb[4]) cannotContain = true;
                }
                if (cannotContain) counter++;

            }

            Console.WriteLine("Part One -> " + counter);
        }
        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int[][] sbPairs = new int[data.Length][];

            for (int d = 0; d < data.Length; d++)
            {
                int[] c = ParseRow(data[d]);
                int dist = Math.Abs(c[0] - c[2]) + Math.Abs(c[1] - c[3]); // manhattan distance
                c[4] = dist;
                sbPairs[d] = c;
            }


            int maxCoord = mode == "debug" ? 20 : 4000000;
            ulong tuningFrequency = 0;
            int[,] offsets = { { 1, 1 }, { -1, 1 }, { -1, -1 }, { 1, -1 } };

            bool signalFound = false;
            foreach (int[] sb in sbPairs)
            {
                int m = sb[4] + 1;
                int i = sb[0];
                int j = sb[1] - m;

                for (int o = 0; o < 4; o++)
                {

                    for (int _ = 0; _ <= m; _++)
                    {
                        if (i < 0 || j < 0 || i > maxCoord || j > maxCoord)
                        {
                            i += offsets[o, 0];
                            j += offsets[o, 1];
                            continue;
                        }
                        signalFound = true;
                        foreach (int[] sb2 in sbPairs)
                        {

                            int mx = Math.Abs(sb2[0] - i);
                            int my = Math.Abs(sb2[1] - j);

                            string id = $"{i},{j}";
                            if (mx + my <= sb2[4])
                            {
                                signalFound = false;
                                break;
                            }
                        }
                        if (signalFound)
                        {
                            tuningFrequency = Convert.ToUInt64(i) * Convert.ToUInt64(4000000) + Convert.ToUInt64(j);
                            break;
                        }
                        i += offsets[o, 0];
                        j += offsets[o, 1];
                    }
                    if (signalFound) break;

                }
                if (signalFound) break;
            }
            Console.WriteLine("Part Two -> " + tuningFrequency);
        }

    }
}
