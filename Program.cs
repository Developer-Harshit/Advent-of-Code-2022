namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day15.PartOne(mode);
            Day15.PartTwo(mode);
        }
    }
}

    