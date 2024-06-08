namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day18.PartOne(mode);
            Day18.PartTwo(mode);
        }
    }
}

