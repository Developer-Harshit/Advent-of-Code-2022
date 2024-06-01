namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day12.PartOne(mode);
            Day12.PartTwo(mode);
        }
    }
}

    