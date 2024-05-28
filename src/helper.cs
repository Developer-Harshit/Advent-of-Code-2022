

using System.IO;


namespace AOC
{
    class Helper
    {
        public static string debugPath = "./data/debug.txt";
        public static string mainPath = "./data/main.txt";

        public static bool WithinBounds(int x, int y, int width, int height)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
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
