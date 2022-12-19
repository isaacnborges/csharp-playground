#region 2D Array DS
//class Solution
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("2D Array DS");
//        Console.WriteLine("Informe as paradas: ");

//        List<List<int>> arr = new List<List<int>>();

//        for (int i = 0; i < 6; i++)
//        {
//            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
//        }

//        int result = Result.HourglassSum(arr);

//        Console.WriteLine("Resultado: " + result);
//        Console.ReadLine();
//    }
//}

//class Result
//{
////example input

////1 1 1 0 0 0
////0 1 0 0 0 0
////1 1 1 0 0 0
////0 0 2 4 4 0
////0 0 0 2 0 0
////0 0 1 2 4 0

////1 1 1 0 0 0
////0 1 0 0 0 0
////1 1 1 0 0 0
////0 9 2 -4 -4 0
////0 0 0 -2 0 0
////0 0 -1 -2 -4 0

////-9 -9 -9 1 1 1
////0 -9 0 4 3 2
////-9 -9 -9 1 2 3
////0 0 8 6 6 0
////0 0 0 -2 0 0
////0 0 1 2 4 0

//    public static int HourglassSum(List<List<int>> arr)
//    {
//        var totalMax = new List<int>();

//        for (int i = 0; i <= 3; i++)
//        {
//            for (int j = 0; j <= 3; j++)
//            {
//                var sumOfOneHourglass = arr[i][j] +
//                                        arr[i][j + 1] +
//                                        arr[i][j + 2] +
//                                        arr[i + 1][j + 1] +
//                                        arr[i + 2][j] +
//                                        arr[i + 2][j + 1] +
//                                        arr[i + 2][j + 2];

//                totalMax.Add(sumOfOneHourglass);
//            }
//        }

//        return totalMax.Max();
//    }
//}
#endregion

#region Array Left Rotation
//class Solution
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("Array Left Rotation");
//        Console.WriteLine("Informe as paradas: ");

//        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

//        int n = Convert.ToInt32(firstMultipleInput[0]);

//        int d = Convert.ToInt32(firstMultipleInput[1]);

//        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

//        List<int> result = Result.RotLeft(a, d);

//        Console.WriteLine("Resultado: " + string.Join(" ", result));
//    }
//}

//class Result
//{
//////example input
/////
////5 4
////1 2 3 4 5

////20 10
////41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51

//    public static List<int> RotLeft(List<int> a, int d)
//    {
//        var returnList = new List<int>();
//        for (int i = d; i < a.Count; i++)
//        {
//            returnList.Add(a[i]);
//        }

//        for (int i = 0; i < d; i++)
//        {
//            returnList.Add(a[i]);
//        }

//        return returnList;
//    }
//}

#endregion

#region New Year Chaos
//class Solution
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("New Year Chaos");
//        Console.WriteLine("Informe as paradas: ");

//        int t = Convert.ToInt32(Console.ReadLine().Trim());

//        for (int tItr = 0; tItr < t; tItr++)
//        {
//            int n = Convert.ToInt32(Console.ReadLine().Trim());

//            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

//            Result.MinimumBribes(q);
//        }
//    }
//}

//class Result
//{
//    public static void MinimumBribes(List<int> q)
//    {
//        var i = q.Count;
//        var swapCounter = 0;
//        while (i > 0)
//        {
//            if (q[i - 1] == i)
//            {
//                i--;
//                continue;
//            }
//            else if (q[i - 2] == i)
//            {
//                Swap(q, i - 2, i - 1);
//                swapCounter++;
//            }
//            else if (q[i - 3] == i)
//            {
//                Swap(q, i - 3, i - 2);
//                swapCounter++;
//                Swap(q, i - 2, i - 1);
//                swapCounter++;
//            }
//            else
//            {
//                Console.WriteLine("Too chaotic");
//                break;
//            }

//            i--;
//        }

//        if (i == 0)
//        {
//            Console.WriteLine(swapCounter);
//        }
//    }

//    public static void Swap<T>(List<T> list, int i, int j)
//    {
//        T temp = list[i];
//        list[i] = list[j];
//        list[j] = temp;
//    }
//}
#endregion

#region balanced-brackets
class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine("balanced-brackets");
        Console.WriteLine("Informe as paradas: ");

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = Result.IsBalanced(s);

            Console.WriteLine(result);
        }
    }
}

class Result
{
    public static string IsBalanced(string s)
    {
        if (s.Length % 2 != 0)
            return "NO";

        if (s[0] == '}' || s[0] == ']' || s[0] == ')')
            return "NO";

        var stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '{' || s[i] == '[' || s[i] == '(')
            {
                stack.Push(s[i]);
            }

            if (stack.Count > 0)
            {
                if (s[i] == '}' && stack.Pop() != '{')
                    return "NO";

                if (s[i] == ']' && stack.Pop() != '[')
                    return "NO";

                if (s[i] == ')' && stack.Pop() != '(')
                    return "NO";
            }
        }

        return stack.Count > 0 ? "NO" : "YES";
    }
}
#endregion