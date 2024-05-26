namespace AOC
{

    class Day2
    {


        public static void PartOne(string mode)
        {
            Dictionary<string, int> gameRules = new Dictionary<string, int>
            {
                { "X", 1 },

                { "Y", 2 },
                { "Z", 3 },

                //lose
                {"BX",0},
                {"CY",0},
                {"AZ",0},
                //draw
                {"AX",3},
                {"BY",3},
                {"CZ",3},
                //win
                {"AY",6},
                {"BZ",6},
                {"CX",6},

            };

            string[] data = Helper.ReadAsArray(mode);
            int scoreSum = 0;
            for (int i = 0; i < data.Length; i++)

            {
                string[] strategy = data[i].Split(" ");
                string state = strategy[0] + strategy[1];
                scoreSum += gameRules[state] + gameRules[strategy[1]];
            }
            Console.WriteLine("Result-> " + scoreSum);


        }
        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            Dictionary<string, int> gameRules = new Dictionary<string, int>
            {

                // lose
                { "X", 0 },
                { "AX", 3 },
                { "BX", 1 },
                { "CX", 2 },
                // draw
                { "Y", 3 },
                { "AY", 1 },
                { "BY", 2 },
                { "CY", 3 },
                // win
                { "Z", 6 },
                { "AZ", 2 },
                { "BZ", 3 },
                { "CZ", 1 },


            };

            int scoreSum = 0;
            for (int i = 0; i < data.Length; i++)

            {
                string[] strategy = data[i].Split(" ");
                string state = strategy[0] + strategy[1];
                scoreSum += gameRules[state] + gameRules[strategy[1]];
            }
            Console.WriteLine("Result-> " + scoreSum);
        }

    }
}