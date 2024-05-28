namespace AOC
{
    class Day6
    {
        public static int FindMarker(string mode, int len)
        {
            string data = Helper.ReadAsString(mode);
            for (int i = len; i < data.Length; i++)
            {
                string k = data[(i - len)..i];
                if (k.Distinct().Count() == len)
                    return i;
            }
            return -1;
        }
        public static void PartOne(string mode)
        {
            int result = FindMarker(mode, 4);
            Console.WriteLine("Part One -> " + result);
        }
        public static void PartTwo(string mode)
        {
            int result = FindMarker(mode, 14);
            Console.WriteLine("Part Two -> " + result);
        }

    }
}
