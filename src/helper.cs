

using System.IO;


namespace AOC
{
    class Helper
    {
        public static string debugPath = "./data/debug.txt";
        public static string mainPath = "./data/main.txt";

        public static string ReadAsString(string mode)
        {
            if (mode == "debug")
            {
                return File.ReadAllText(debugPath);
            }

            return File.ReadAllText(mainPath);


        }
        public static string[] ReadAsArray(string mode)
        {
            if (mode == "debug")
            {

                return File.ReadAllLines(debugPath);
            }

            return File.ReadAllLines(mainPath);

        }


    }
}
