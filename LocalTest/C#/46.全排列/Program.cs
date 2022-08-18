Solution solution = new();
int[] nums = { 1, 2, 3 };
var res = solution.Permute(nums);
Console.WriteLine(res);

public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> res = new();
        int len = nums.Length;
        if (len == 0) return res;
        bool[] used = new bool[len];
        Stack<int> path = new Stack<int>(len);
        Dfs(nums, path, used, res);
        return res;
    }

    private void Dfs(int[] nums, Stack<int> path, bool[] used, List<IList<int>> res)
    {
        if (path.Count == nums.Length)
        {
            res.Add(new List<int>(path));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;
            path.Push(nums[i]);
            used[i] = true;
            Dfs(nums, path, used, res);
            used[i] = false;
            path.Pop();
        }
    }
}