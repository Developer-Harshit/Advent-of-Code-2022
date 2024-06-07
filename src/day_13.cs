using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AOC
{
    class Day13
    {

        public static string arrayCheck = "System.Text.Json.Nodes.JsonArray";
        public static int draw = 0;
        public static int correct = 1;
        public static int wrong = -1;
        static int CheckPackerOrder(JsonNode? first, JsonNode? second)
        {

            if (first?.GetType().ToString() != arrayCheck)
                first = JsonArray.Parse($"[{first}]");

            if (second?.GetType().ToString() != arrayCheck)
                second = JsonArray.Parse($"[{second}]");

            if (first == null || second == null) return wrong;
            var o1 = first.AsArray();
            var o2 = second.AsArray();
            int len = Math.Min(o1.Count, o2.Count);
            for (int i = 0; i < len; i++)
            {
                var a = o1[i];
                var b = o2[i];
                if (a == null || b == null) continue;


                if (a.GetType().ToString() == arrayCheck || b.GetType().ToString() == arrayCheck)
                {

                    int res = CheckPackerOrder(a, b);
                    if (res == 0) continue;
                    return res;
                }
                int one = int.Parse(a.ToString());
                int two = int.Parse(b.ToString());
                if (one == two) continue;
                else if (one < two) return correct;
                else return wrong;
            }
            if (o1.Count == o2.Count) return draw;
            else if (o1.Count < o2.Count) return correct;
            else return wrong;

        }
        public static void PartOne(string mode)
        {
            string[] data = Helper.ReadAsArray(mode);
            int sum = 0;

            for (int i = 0; i < data.Length; i += 3)
            {
                var first = JsonArray.Parse(data[i]);
                var second = JsonArray.Parse(data[i + 1]);

                if (first == null || second == null) continue;
                if (CheckPackerOrder(first, second) == correct) sum += i / 3 + 1;

            }

            Console.WriteLine("Part One -> " + sum);
        }
        static void BubbleSort(List<JsonNode> arr)
        {
            // inti, j, temp;
            // for (i = (array_size - 1); i>= 0; i--):
            //     for (j = 1; j <= i; j++):
            //         if (numbers[j-1] > numbers[j]){
            //             temp = numbers[j-1];
            //             numbers[j-1] = numbers[j];
            //             numbers[j] = temp;
            int n = arr.Count;
            for (int i = n - 1; i > -1; i--)
            {
                for (int j = 1; j <= i; j++)
                {


                    if (CheckPackerOrder(arr[j], arr[j - 1]) == correct)
                    {
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                    }
                }

            }
        }

        public static void PartTwo(string mode)
        {
            string[] data = [.. Helper.ReadAsArray(mode), "\n", "[[2]]", "[[6]]"];

            List<JsonNode> arr = [];
            for (int i = 0; i < data.Length; i += 3)
            {
                JsonNode? first = JsonArray.Parse(data[i]);
                JsonNode? second = JsonArray.Parse(data[i + 1]);
                if (first == null || second == null) continue;

                arr.Add(first);
                arr.Add(second);

            }
            BubbleSort(arr);

            int decoderKey = 1;
            for (int i = 0; i < arr.Count; i++)
            {
                string h = arr[i].ToString().Replace("\r\n", "").Replace(" ", "");
                if (h == "[[2]]" || h == "[[6]]") decoderKey *= i + 1;
            }

            Console.WriteLine("Part Two -> " + decoderKey);
        }

    }
}
