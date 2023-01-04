#region Problem - Baseball game
class CalPoints
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Baseball game");
        Console.Write("Input: ");

        var solution = new Solution();
        var space = new char[] { ' ' };

        var ops = Console.ReadLine().Split(space);

        Console.WriteLine();
        var output = solution.CalPoints(ops);
        Console.WriteLine("Output: " + output);
    }
}

class Solution
{
    public int CalPoints(string[] ops)
    {
        var points = new List<int>();
        int score;

        for (int i = 0; i < ops.Length; i++)
        {
            if (ops[i] == "+")
            {
                score = points[points.Count - 1] + points[points.Count - 2];
                points.Add(score);
            }
            else if (ops[i] == "D")
            {
                score = points[points.Count - 1] * 2;
                points.Add(score);
            }
            else if (ops[i] == "C")
            {
                score = points.Count - 1;
                points.RemoveAt(score);
            }
            else
            {
                score = int.Parse(ops[i]);
                points.Add(score);
            }
        }

        return points.Sum();
    }
}
#endregion