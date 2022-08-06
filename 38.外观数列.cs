/*
 * @lc app=leetcode.cn id=38 lang=csharp
 *
 * [38] 外观数列
 */

// @lc code=start
public class Solution
{
    public string CountAndSay(int n)
    {
        string res = "1";
        for (int i = 2; i <= n; i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0, start = 0; j < res.Length; start = j)
            {
                while (j < res.Length && res[j] == res[start])
                {
                    j++;
                }
                sb.Append(j - start).Append(res[start]);
            }
            res = sb.ToString();
        }
        return res;
    }
}
// @lc code=end

