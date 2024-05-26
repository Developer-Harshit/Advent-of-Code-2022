import os
import sys
folder_number = input("Enter folder number -> ")
folder_path = "./src/day_" + str(folder_number)  + ".cs"



f = open(folder_path, "a")
f.write(
    """namespace AOC
{
    class Day""" + folder_number +"""
    {
        public static void PartOne(string mode)
        {
            // string[] data = Helper.ReadAsArray(mode);
            string data = Helper.ReadAsString(mode);
            Console.WriteLine("Part One -> " + data);
            
        }
        public static void PartTwo(string mode)
        {
            // string[] data = Helper.ReadAsArray(mode);
            string data = Helper.ReadAsString(mode);
            Console.WriteLine("Part Two -> " + data);
            
        }

    }
}
"""
)
f.close()

f = open("./Program.cs", "w")
f.write(
    """namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {

            string mode = "debug";
            if (args.Length > 0) mode = args[0];
            """ + f"""Day{folder_number}.PartOne(mode);
            Day{folder_number}.PartTwo(mode);""" + """
        }
    }
}

    """
)
f.close()
# os.popen("code ./" + folder_path + " -r")
