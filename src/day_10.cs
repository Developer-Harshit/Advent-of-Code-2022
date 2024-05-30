namespace AOC
{
    class Day10
    {
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int[] nth = [20, 60, 100, 140, 180, 220];
            int cycles = 1;
            int x = 1;

            int signalStrength = 0;
            foreach (string item in data)
            {
                string[] cmd = item.Split(" ");
                cycles++;
                if (nth.Contains(cycles)) signalStrength += cycles * x;

                if (cmd[0] == "addx")
                {

                    int val = int.Parse(cmd[1]);
                    x += val;
                    cycles++;
                    if (nth.Contains(cycles)) { signalStrength += cycles * x; }
                }
            }
            Console.WriteLine("Part One -> " + signalStrength);

        }
        public static void PartTwo(string mode)
        {

            string[] data = Helper.ReadAsArray(mode);



            int cycles = 0;
            int x = 1;
            int i = 0;
            int val = 0;
            string sprite = "";

            while (i < data.Length)
            {
                int k = cycles % 40;
                if (val != 0)
                {
                    cycles++;
                    if (k == x - 1 || k == x || k == x + 1)
                        sprite += "#";
                    else sprite += ".";
                    x += val;
                    val = 0;
                    i++;
                    continue;
                }

                string[] cmd = data[i].Split(" ");
                cycles++;
                if (k == x - 1 || k == x || k == x + 1)
                    sprite += "#";
                else sprite += ".";

                if (cmd[0] == "addx") val = int.Parse(cmd[1]);
                else i++;
            }


            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 40; col++)
                {
                    int idx = col + row * 40;
                    Console.Write(" " + sprite[idx]);
                }
                Console.WriteLine();
            }


        }

    }
}
