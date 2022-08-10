/*
 * @lc app=leetcode.cn id=40 lang=csharp
 *
 * [40] 组合总和 II
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
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

    public void Dsf2(int[] candidates, int begin, int len, int target, Stack<int> path, IList<IList<int>> res)
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
            if (i > begin && candidates[i] == candidates[i - 1])
            {
                continue;
            }
            path.Push(candidates[i]);
            Dsf2(candidates, i + 1, len, target - candidates[i], path, res);
            path.Pop();
        }
    }
}
// @lc code=end

