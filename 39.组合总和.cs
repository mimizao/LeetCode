/*
 * @lc app=leetcode.cn id=39 lang=csharp
 *
 * [39] 组合总和
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
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

    public void dfs(int[] candidates, int begin, int len, int target, Stack<int> path, IList<IList<int>> res)
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
// @lc code=end

