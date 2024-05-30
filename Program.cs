namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day9.PartOne(mode);
            Day9.PartTwo(mode);
        }
    }
}

