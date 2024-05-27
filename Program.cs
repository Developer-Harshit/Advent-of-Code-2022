namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day4.PartOne(mode);
            Day4.PartTwo(mode);
        }
    }
}

    