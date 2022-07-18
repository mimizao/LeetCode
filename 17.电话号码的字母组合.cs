/*
 * @lc app=leetcode.cn id=17 lang=csharp
 *
 * [17] 电话号码的字母组合
 */

// @lc code=start
public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return new List<string>();
        }
        IList<string> res = new List<string>();
        Dictionary<char, string> dic = new Dictionary<char, string>
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };
        res = GetNewList(res, dic, digits, 0, "");
        return res;
    }

    public IList<string> GetNewList(IList<string> res, Dictionary<char, string> dic, string digits, int index, string suffix)
    {
        if (index == digits.Length)
        {
            res.Add(suffix);
            return res;
        }
        else
        {
            string str = dic[digits[index]];
            for (int i = 0; i < str.Length; i++)
            {
                res = GetNewList(res, dic, digits, index + 1, suffix + str[i]);
            }
        }
        return res;
    }
}
// @lc code=end

