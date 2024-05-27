namespace AOC
{
    class Day4
    {
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int count = 0;
            foreach (string item in data)
            {
                string[] arr = item.Split(",");
                int[] a = Array.ConvertAll(arr[0].Split("-"), int.Parse);
                int[] b = Array.ConvertAll(arr[1].Split("-"), int.Parse);
                if ((a[0] >= b[0] && a[0] <= b[1] && a[1] >= b[0] && a[1] <= b[1]) || (b[0] >= a[0] && b[0] <= a[1] && b[1] >= a[0] && b[1] <= a[1]))

                {
                    count++;
                }
            }
            Console.WriteLine("Part One -> " + count);

        }
        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int count = 0;
            foreach (string item in data)
            {
                string[] arr = item.Split(",");
                int[] a = Array.ConvertAll(arr[0].Split("-"), int.Parse);
                int[] b = Array.ConvertAll(arr[1].Split("-"), int.Parse);
                if ((a[0] >= b[0] && a[0] <= b[1]) || (a[1] >= b[0] && a[1] <= b[1]) || (b[0] >= a[0] && b[0] <= a[1]) || (b[1] >= a[0] && b[1] <= a[1]))

                {
                    count++;
                }
            }
            Console.WriteLine("Part Two -> " + count);

        }

    }
}
