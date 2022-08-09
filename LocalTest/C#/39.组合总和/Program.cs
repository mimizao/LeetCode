int[] candidates = new int[] { 2, 3, 6,7 };
int target = 7;
var res = Solution.CombinationSum(candidates, target);
Console.WriteLine(res);

public class Solution
{
    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        int len = candidates.Length;
        IList<IList<int>> res = new List<IList<int>>();
        if (len == 0)
        {
            return res;
        }
        Stack<int> path = new Stack<int>();
        dfs(candidates, 0, len, target, path, res);
        return res;
    }

    public static void dfs(int[] candidates, int begin, int len, int target, Stack<int> path, IList<IList<int>> res)
    {
        if (target < 0)
        {
            return;
        }
        if (target == 0)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = begin; i < len; i++)
        {
            path.Push(candidates[i]);
            dfs(candidates, i, len, target - candidates[i], path, res);
            path.Pop();
        }
    }
}