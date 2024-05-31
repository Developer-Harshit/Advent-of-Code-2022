namespace AOC
{
    public class Monkey
    {
        readonly Queue<ulong> items = new Queue<ulong>();
        readonly string[] operation = new string[3];
        public readonly ulong test;
        readonly int trueMonkey;
        readonly int falseMonkey;
        readonly List<Monkey> mList;
        public ulong inspectCount = 0;
        ulong currItem = 0;

        public Monkey(List<Monkey> _mList, string[] d)
        {
            mList = _mList;
            var _temp = d[0].Replace(" ", "").Split(':')[1].Split(',');
            foreach (string item in _temp)
            {
                items.Enqueue(ulong.Parse(item));
            }
            operation = d[1].Split(" = ")[1].Split(' ');
            test = ulong.Parse(d[2].Split(' ')[^1]);
            trueMonkey = int.Parse(d[3].Split(' ')[^1]);
            falseMonkey = int.Parse(d[4].Split(' ')[^1]);
        }
        public void Update(ulong superModulo)
        {
            int len = items.Count;
            for (int _ = 0; _ < len; _++)
            {
                InspectItem();
                if (superModulo == 0) GetBored();
                else ManageWorry(superModulo);
                TestItem();

            }
        }

        public void InspectItem()
        {
            currItem = items.Dequeue();
            inspectCount += 1;

            ulong right = ulong.Parse(operation[2].Replace("old", currItem + ""));
            string op = operation[1];
            if (op == "+") currItem += right;
            else if (op == "*") currItem *= right;
            else Console.WriteLine("ERROR IN INSPECT ITEM");


        }
        public void GetBored()
        {
            currItem /= 3;
        }
        public void TestItem()
        {
            int currMonkey = falseMonkey;
            if (currItem % test == 0) currMonkey = trueMonkey;
            ThrowItem(currMonkey);

        }
        public void ThrowItem(int idx)
        {
            mList[idx].ReceiveItem(currItem);
        }

        public void ReceiveItem(ulong item)
        {
            items.Enqueue(item);
        }
        public void ManageWorry(ulong superModulo)
        {

            currItem %= superModulo;
        }

    }

    class Day11
    {

        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int rounds = 20;
            List<Monkey> mList = [];
            for (int i = 0; i < data.Length; i += 7)
            {
                string[] d = data[(i + 1)..(i + 6)];
                mList.Add(new Monkey(mList, d));
            }
            for (int _ = 0; _ < rounds; _++)
            {
                for (int m = 0; m < mList.Count; m++)
                {
                    mList[m].Update(0);
                }
            }

            ulong[] cList = new ulong[mList.Count];
            for (int m = 0; m < mList.Count; m++)
            {
                ulong count = mList[m].inspectCount;
                cList[m] = count;
            }

            Array.Sort(cList);
            ulong monkeyBusiness = cList[^1] * cList[^2];


            Console.WriteLine("Part One -> " + monkeyBusiness);

        }
        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int rounds = 10000;
            List<Monkey> mList = [];
            for (int i = 0; i < data.Length; i += 7)
            {
                string[] d = data[(i + 1)..(i + 6)];
                mList.Add(new Monkey(mList, d));
            }
            ulong superModulo = mList.Aggregate(1ul, (curr, monke) => curr *= monke.test);
            Console.WriteLine(superModulo + " superr");
            for (int _ = 0; _ < rounds; _++)
            {
                for (int m = 0; m < mList.Count; m++)
                {
                    mList[m].Update(superModulo);
                }
            }

            ulong[] cList = new ulong[mList.Count];
            for (int m = 0; m < mList.Count; m++)
            {
                ulong count = mList[m].inspectCount;
                cList[m] = count;
            }

            Array.Sort(cList);
            ulong monkeyBusiness = cList[^1] * cList[^2];
            Console.WriteLine("Part Two -> " + monkeyBusiness);

        }

    }
}
