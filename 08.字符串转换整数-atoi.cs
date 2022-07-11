/*
 * @lc app=leetcode.cn id=8 lang=csharp
 *
 * [8] 字符串转换整数 (atoi)
 */

// @lc code=start
public class Solution
{
    public int MyAtoi(string s)
    {
        int res = 0;
        if (s.Length == 0) return 0;
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                count++;
            }
            else
            {
                break;
            }
        }
        s = s.Substring(count);
        if (s.Length == 0) return 0;
        int flag = 1;
        int index = 0;
        if (s[0] == '-')
        {
            flag = -1;
            index++;
        }
        if (s[0] == '+')
        {
            index++;
        }
        for (int i = index; i < s.Length; i++)
        {
            int tmp = s[i] - '0';
            if (tmp < 0 || tmp > 9)
            {
                return res;
            }
            if (res > 214748364 || (res == 214748364 && tmp > 7))
            {
                return 2147483647;
            }
            if (res < -214748364 || (res == -214748364 && tmp * flag < -8))
            {
                return -2147483648;
            }
            res = res * 10 + tmp * flag;
        }
        return res;
    }
}
// @lc code=end

