using System.Collections.Generic;
namespace AOC
{
    class Day3
    {
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int sum = 0;
            for (int i = 0; i < data.Length; i++)

            {
                string s = data[i];


                Index middle = s.Length / 2;


                int k = s[..middle].Intersect(s[middle..]).First();

                sum += k - 38;
                if (k > 90) sum -= 58;

                // Console.WriteLine(k + " " + arr.First());
            }
            Console.WriteLine("Part One -> " + sum);
        }


        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int sum = 0;
            for (int i = 0; i < data.Length; i += 3)

            {

                string s1 = data[i];
                string s2 = data[i + 1];
                string s3 = data[i + 2];

                // HashSet<char> arr = s1.ToHashSet();
                int k = s1.Intersect(s2).Intersect(s3).First();


                sum += k - 38;
                if (k > 90) sum -= 58;





            }
            Console.WriteLine("Part Two -> " + sum);
        }

    }
}
