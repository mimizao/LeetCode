/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = new List<string>() { };
        Generate(result, "", 0, 0, n);
        return result;
    }
    public void Generate(IList<string> result, string str, int leftCount, int rightCount, int n)
    {
        if (leftCount > n || rightCount > n || rightCount > leftCount)
        {
            return;
        }
        if (leftCount == n && rightCount == n)
        {
            result.Add(str);
        }
        Generate(result, str + "(", leftCount + 1, rightCount, n);
        Generate(result, str + ")", leftCount, rightCount + 1, n);
        return;
    }
}
// @lc code=end

