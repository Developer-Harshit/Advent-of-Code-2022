

namespace AOC
{
    class Day12
    {
        readonly public static int[,] offsets = { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } }; // Up Down Left Right

        public class Node(int _x, int _y, int _level, int[] _dim)
        {
            readonly int x = _x;
            readonly int y = _y;
            public readonly int level = _level;
            readonly int[] dim = _dim;
            public int cost = int.MaxValue / 2;



            public List<int> GetNeighbours()
            {

                List<int> neighbours = [];
                for (int i = 0; i < 4; i++)
                {
                    int kx = x + offsets[i, 0];
                    int ky = y + offsets[i, 1];
                    if (!Helper.WithinBounds(kx, ky, dim[0], dim[1])) continue;
                    neighbours.Add(Helper.FindIndex(kx, ky, dim));

                }
                return neighbours;
            }
        }

        public static Node[] Dijkstra(string[] data, int start)
        {

            int[] dim = [data[0].Length, data.Length];
            Node[] nodes = new Node[dim[0] * dim[1]];
            HashSet<Node> Q = new HashSet<Node>();

            for (int j = 0; j < dim[1]; j++)
            {
                for (int i = 0; i < dim[0]; i++)
                {
                    char level = data[j][i];
                    if (level == 'S') level = 'a';
                    else if (level == 'E') level = 'z';

                    Node n = new Node(i, j, Convert.ToInt32(level), dim);
                    int idx = Helper.FindIndex(i, j, dim);
                    nodes[idx] = n;
                    Q.Add(n);
                }
            }
            nodes[start].cost = 0;


            while (Q.Count != 0)
            {
                Node u = Q.OrderBy(x => x.cost).First();
                Q.Remove(u);

                List<int> neighbours = u.GetNeighbours();
                foreach (int nidx in neighbours)
                {
                    Node v = nodes[nidx];
                    if (!Q.Contains(v)) continue;
                    int delta = u.level - v.level;
                    if (delta > 1) continue;
                    int newCost = u.cost + 1;

                    if (newCost < v.cost)
                        v.cost = newCost;
                }
            }

            return nodes;
        }
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            (int low, int high) = FindPoints(mode);
            Node[] nodes = Dijkstra(data, high);
            int steps = nodes[low].cost;
            Console.WriteLine("Part One -> " + steps);

        }
        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            (int low, int high) = FindPoints(mode);
            Node[] nodes = Dijkstra(data, high);
            int steps = nodes.Aggregate(int.MaxValue, (curr, n) => n.level == 'a' ? Math.Min(curr, n.cost) : curr);
            Console.WriteLine("Part Two -> " + steps);

        }
        static Tuple<int, int> FindPoints(string mode)
        {
            string data = Helper.ReadAsString(mode).Replace("\r\n", "");
            return new Tuple<int, int>(data.IndexOf('S'), data.IndexOf('E'));
        }

    }
}
