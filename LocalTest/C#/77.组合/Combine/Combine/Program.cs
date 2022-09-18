const int n = 10, k = 8;
Solution solution = new Solution();
var res = solution.Combine(n, k);
Console.WriteLine(res);

public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Stack<int> path = new Stack<int>();
        bool[] used = new bool[n + 1];
        Dfs(res, path, used, n, k);
        return res;
    }

    private void Dfs(IList<IList<int>> res, Stack<int> path, bool[] used, int n, int k)
    {
        if (path.Count == k)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = 1; i <= n; i++)
        {
            if (used[i] || (path.Count > 0 && i > path.Peek()))
            {
                continue;
            }
            used[i] = true;
            path.Push(i);
            Dfs(res, path, used, n, k);
            path.Pop();
            used[i] = false;
        }
    }
}