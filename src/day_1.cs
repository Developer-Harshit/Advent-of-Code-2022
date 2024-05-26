namespace AOC
{
    class Day1
    {
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int calories = 0;
            int maxCalories = 0;
            for (int i = 0; i < data.Length; i++)
            {
                string value = data[i].Replace(" ", "");

                if (value == "")
                {
                    maxCalories = Math.Max(calories, maxCalories);
                    calories = 0;
                    continue;
                }

                calories += Convert.ToInt32(value);
            }
            Console.WriteLine("Result-> " + maxCalories);


        }
        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int calories = 0;
            int[] maxCalories = { 0, 0, 0 };


            for (int i = 0; i < data.Length; i++)
            {
                string value = data[i].Replace(" ", "");
                if (value != "")
                    calories += Convert.ToInt32(value);

                if (value == "" || i == (data.Length - 1))
                {
                    Array.Sort(maxCalories);
                    maxCalories[0] = Math.Max(calories, maxCalories[0]);
                    calories = 0;
                    continue;
                }


            }
            Console.WriteLine("Result-> " + maxCalories.Sum());

        }

    }
}
