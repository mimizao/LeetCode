/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> res = new();
        var len = nums.Length;
        if (len == 0) return res;
        var used = new bool[len];
        var path = new Stack<int>(len);
        Dfs(nums, len, 0, path, used, res);
        return res;
    }

    private void Dfs(int[] nums, int len, int depth, Stack<int> path, bool[] used, List<IList<int>> res)
    {
        if (depth == len)
        {
            res.Add(new List<int>(path));
            return;
        }

        for (var i = 0; i < len; i++)
        {
            if (used[i]) continue;
            path.Push(nums[i]);
            used[i] = true;
            Dfs(nums, len, depth + 1, path, used, res);
            used[i] = false;
            path.Pop();
        }
    }
}
// @lc code=end

