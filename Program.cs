namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day14.PartOne(mode);
            Day14.PartTwo(mode);
        }
    }
}

