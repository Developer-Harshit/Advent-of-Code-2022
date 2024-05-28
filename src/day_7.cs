using System.Diagnostics.CodeAnalysis;

namespace AOC
{

    class Day7
    {
        public static string rootDir = "./";

        public static void ExecuteCommands(string mode, Dictionary<string, int> files, Dictionary<string, int> directories)
        {
            string[] data = Helper.ReadAsArray(mode);

            Stack<string> stack = [];
            directories.Add(rootDir, 0);
            string path = "";

            foreach (string s in data)
            {
                string[] cmd = s.Split(' ');

                if (cmd[0] == "$" && cmd[1] == "cd")
                {
                    switch (cmd[2])
                    {
                        case "/":
                            stack.Clear();
                            break;
                        case "..":

                            stack.Pop();

                            break;
                        default:
                            stack.Push(cmd[2]);
                            break;
                    }
                    continue;
                }
                else if (cmd[0] == "$" && cmd[1] == "ls")
                {
                    path = rootDir + string.Join("/", stack.Reverse());
                    continue;
                }

                string key = path + '/' + cmd[1] + "/";
                if (path == rootDir) key = rootDir + cmd[1] + "/";
                if (cmd[0] == "dir")
                {
                    directories[key] = 0;
                    continue;
                }
                files[key] = int.Parse(cmd[0]);
            }
            foreach (var pair in files)
            {
                foreach (var dir in directories.Keys)
                {
                    if (pair.Key.Contains(dir)) directories[dir] += pair.Value;
                }

            }
        }

        public static void PartOne(string mode)
        {
            Dictionary<string, int> f = [];
            Dictionary<string, int> d = [];

            ExecuteCommands(mode, f, d);


            int sum = d.Aggregate(0,
            (curr, pair) =>
            {
                if (pair.Value <= 100000) curr += pair.Value;
                return curr;
            });

            Console.WriteLine("Part One -> " + sum);

        }
        public static void PartTwo(string mode)
        {

            Dictionary<string, int> f = [];
            Dictionary<string, int> d = [];

            ExecuteCommands(mode, f, d);


            int totalSpace = d["./"];
            int maxSpace = 70000000;
            int freeSpace = 30000000;
            int k = totalSpace - (maxSpace - freeSpace);
            int result = d.Aggregate(totalSpace,
            (curr, pair) =>
            {
                if (pair.Value >= k && pair.Value < curr) curr = pair.Value;
                return curr;
            });

            Console.WriteLine("Part Two -> " + result);

        }

    }
}
