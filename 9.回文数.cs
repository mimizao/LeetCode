/*
 * @lc app=leetcode.cn id=9 lang=csharp
 *
 * [9] 回文数
 */

// @lc code=start
public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        string s = x.ToString();
        int left = 0;
        int right = s.Length - 1;
        while (left >= right)
        {
            if (s[left] == s[right])
            {
                left--;
                right++;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

public class Solution1
{
    public bool IsPalindrome(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0)) { return false; }
        int revertedNumber = 0;
        while (x > revertedNumber)
        {
            revertedNumber = revertedNumber * 10 + x % 10;
            x /= 10;
        }
        return x == revertedNumber || x == revertedNumber / 10;
    }
}