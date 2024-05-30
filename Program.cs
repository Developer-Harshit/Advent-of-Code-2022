namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            Day10.PartOne(mode);
            Day10.PartTwo(mode);
        }
    }
}

    