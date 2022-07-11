/*
 * @lc app=leetcode.cn id=10 lang=csharp
 *
 * [10] 正则表达式匹配
 */

// @lc code=start
public class Solution
{
    public bool IsMatch(string s, string p)
    {
        int m = s.Length;
        int n = p.Length;

        bool[,] f = new bool[m + 1, n + 1];
        f[0, 0] = true;
        for (int i = 0; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                {
                    f[i, j] = f[i, j - 2];
                    if (Matches(s, p, i, j - 1))
                    {
                        f[i, j] = f[i, j] || f[i - 1, j];
                    }
                }
                else
                {
                    if (Matches(s, p, i, j))
                    {
                        f[i, j] = f[i - 1, j - 1];
                    }
                }
            }
        }
        return f[m, n];
    }

    public bool Matches(string s, string p, int i, int j)
    {
        if (i == 0) return false;
        if (p[j - 1] == '.') return true;
        return s[i - 1] == p[j - 1];
    }
}
// @lc code=end

