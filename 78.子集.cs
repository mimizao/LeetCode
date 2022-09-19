/*
 * @lc app=leetcode.cn id=78 lang=csharp
 *
 * [78] 子集
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        int len = nums.Length;
        IList<IList<int>> res = new List<IList<int>>();
        IList<IList<int>> temp = new List<IList<int>>();
        res.Add(new List<int>());
        temp.Add(new List<int>());
        for (int i = 1; i <= len; i++)
        {
            bool[] used = new bool[len];
            Stack<int> path = new();
            Dfs(res, nums, used, path, 0, i);
        }
        return res;
    }

    private void Dfs(IList<IList<int>> res, int[] nums, bool[] used, Stack<int> path, int begin, int count)
    {
        if (path.Count == count)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = begin; i < nums.Length; i++)
        {
            if (used[i]) continue;
            used[i] = true;
            path.Push(nums[i]);
            Dfs(res, nums, used, path, i + 1, count);
            path.Pop();
            used[i] = false;
        }
    }
}
// @lc code=end

