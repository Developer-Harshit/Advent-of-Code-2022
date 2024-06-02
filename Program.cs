namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day13.PartOne(mode);
            Day13.PartTwo(mode);
        }
    }
}

