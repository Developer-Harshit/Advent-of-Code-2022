using System.Text;

namespace AOC
{
    using Position = Tuple<int, int, int>;
    class Day18
    {
        public static List<int[]> offsets = [
            [0,0,1],[0,0,-1],[0,1,0],[0,-1,0],[1,0,0],[-1,0,0]
        ];
        public static int[] xbounds = [int.MaxValue, 0];
        public static int[] ybounds = [int.MaxValue, 0];
        public static int[] zbounds = [int.MaxValue, 0];

        public static string ID(int[] v)
        {
            return $"{v[0]},{v[1]},{v[2]}";
        }
        public static string ID(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            return $"{ID(p1)},{ID(p2)},{ID(p3)},{ID(p4)}";
        }
        public static void SetBounds(Position cube)
        {
            (int x, int y, int z) = cube;
            xbounds[0] = Math.Min(xbounds[0], x - 3);
            xbounds[1] = Math.Max(xbounds[1], x + 3);

            ybounds[0] = Math.Min(ybounds[0], y - 3);
            ybounds[1] = Math.Max(ybounds[1], y + 3);

            zbounds[0] = Math.Min(zbounds[0], z - 3);
            zbounds[1] = Math.Max(zbounds[1], z + 3);

        }
        public static string[] ParseCubeFace(Position cube)
        {

            (int x, int y, int z) = cube;

            int w = 1;

            int[] p1 = [x, y, z];
            int[] p2 = [x, y - w, z];
            int[] p3 = [x + w, y - w, z];
            int[] p4 = [x + w, y, z];

            int[] p5 = [x, y, z + w];
            int[] p6 = [x, y - w, z + w];
            int[] p7 = [x + w, y - w, z + w];
            int[] p8 = [x + w, y, z + w];


            return [
                    // left face
                    ID(p1,p2,p6,p5),
                    // right face
                    ID(p4,p3,p7,p8),
                    //top face
                    ID(p1,p2,p3,p4),
                    // bottom face
                     ID(p5,p6,p7,p8),
                    // front face
                     ID(p1,p5,p8,p4),
                    // back face
                    ID(p2,p6,p7,p3),
            ];

        }
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            HashSet<string> a = [];
            for (int i = 0; i < data.Length; i++)
            {
                int[] ele = Array.ConvertAll(data[i].Split(','), int.Parse);
                Position curr = new(ele[0], ele[1], ele[2]);
                string[] faces = ParseCubeFace(curr);
                foreach (string id in faces)
                {
                    if (!a.Remove(id)) a.Add(id);
                }
            }
            Console.WriteLine("Part One -> " + a.Count);
        }




        public static void PartTwo(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            HashSet<string> a = [];
            List<Position> cubes = [];
            for (int i = 0; i < data.Length; i++)
            {
                int[] ele = Array.ConvertAll(data[i].Split(','), int.Parse);
                Position curr = new(ele[0], ele[1], ele[2]);
                SetBounds(curr);
                cubes.Add(curr);
            }

            // // bfs
            int exterior = 0;
            HashSet<Position> visited = [];
            Stack<Position> k = [];
            k.Push(new(xbounds[0] + 1, ybounds[0] + 1, zbounds[0] + 1));
            k.Push(new(xbounds[1] - 1, ybounds[1] - 1, zbounds[1] - 1));

            while (k.Count > 0)
            {
                var ele = k.Pop();
                (int x, int y, int z) = ele;

                if (cubes.Contains(ele))
                {
                    exterior += 1;
                    continue;
                }

                if (x < xbounds[0] || x > xbounds[1] || y < ybounds[0] || y > ybounds[1] || z < zbounds[0] || z > zbounds[1]) continue;
                if (visited.Contains(ele)) continue;

                visited.Add(ele);

                // add neighbours within bounds
                foreach (int[] o in offsets)
                {
                    k.Push(new(x + o[0], y + o[1], z + o[2]));
                }
            }

            Console.WriteLine("Part Two -> " + exterior);
        }

    }
}
