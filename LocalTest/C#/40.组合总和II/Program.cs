int[] candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
int target = 8;
IList<IList<int>> res = Solution.CombinationSum2(candidates, target);
Console.WriteLine(res);

public class Solution
{
    public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        int len = candidates.Length;
        IList<IList<int>> res = new List<IList<int>>();
        if (len == 0)
        {
            return res;
        }
        Array.Sort(candidates);
        Stack<int> path = new Stack<int>();
        Dsf2(candidates, 0, len, target, path, res);
        return res;
    }

    public static void Dsf2(int[] candidates, int begin, int len, int target, Stack<int> path, IList<IList<int>> res)
    {
        if (target == 0)
        {
            List<int> newPath = new(path);
            newPath.Sort();
            res.Add(newPath);
            return;
        }
        for (int i = begin; i < len; i++)
        {
            if (target - candidates[i] < 0)
            {
                break;
            }
            if (i>begin && candidates[i] == candidates[i - 1])
            {
                continue;
            }
            path.Push(candidates[i]);
            Dsf2(candidates, i + 1, len, target - candidates[i], path, res);
            path.Pop();
        }
    }
}