namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day2.PartOne(mode);
            Day2.PartTwo(mode);
        }
    }
}

    