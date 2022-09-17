/*
 * @lc app=leetcode.cn id=76 lang=csharp
 *
 * [76] 最小覆盖子串
 */

// @lc code=start
public class Solution
{
    public string MinWindow(string s, string t)
    {
        int sLen = s.Length;
        int tLen = t.Length;
        if (sLen < tLen) return "";
        Dictionary<char, int> tDic = new();
        foreach (char c in t)
            if (!tDic.ContainsKey(c))
                tDic[c] = 1;
            else
                tDic[c]++;

        for (int i = 0; i < tLen; i++)
        {
            if (!tDic.ContainsKey(s[i])) continue;

            tDic[s[i]]--;
        }

        if (!tDic.Values.Any(v => v > 0)) return s[..tLen];

        int tempBegin = 0;
        int tempEnd = tLen - 1;
        int begin = -1;
        int end = sLen;

        while (tempBegin < sLen - tLen + 1 && tempEnd < sLen)
        {
            while (tempEnd - tempEnd > end - begin && tempBegin < sLen - tLen + 1 && tempEnd < sLen)
            {
                if (tDic.ContainsKey(s[tempBegin]))
                {
                    tDic[s[tempBegin]]++;
                }

                tempBegin++;
            }

            if (!tDic.Values.Any(v => v > 0))
            {
                if (tempEnd - tempBegin + 1 == tLen)
                {
                    return s.Substring(tempBegin, tempEnd - tempBegin + 1);
                }

                if (tempEnd - tempBegin < end - begin)
                {
                    begin = tempBegin;
                    end = tempEnd;
                }

                if (tDic.ContainsKey(s[tempBegin]))
                {
                    tDic[s[tempBegin]]++;
                }

                tempBegin++;
            }
            else
            {
                if (tempEnd < sLen - 1)
                {
                    tempEnd++;
                    if (tDic.ContainsKey(s[tempEnd]))
                    {
                        tDic[s[tempEnd]]--;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        return begin is -1 ? "" : s.Substring(begin, end - begin + 1);
    }

    public string MinWindow1(string s, string t)
    {
        int sLen = s.Length;
        int tLen = t.Length;
        if (sLen < tLen)
        {
            return "";
        }
        Dictionary<char, int> sDic = new();
        Dictionary<char, int> tDic = new();
        foreach (char c in t)
        {
            tDic[c] = tDic.ContainsKey(c) ? tDic[c] + 1 : 1;
        }
        int count = 0;
        int start = 0;
        int len = int.MaxValue;
        for (int tempStart = 0, tempEnd = 0; tempEnd < sLen; tempEnd++)
        {
            sDic[s[tempEnd]] = sDic.ContainsKey(s[tempEnd]) ? sDic[s[tempEnd]] + 1 : 1;
            if (tDic.ContainsKey(s[tempEnd]) && sDic[s[tempEnd]] <= tDic[s[tempEnd]])
            {
                count++;
            }
            while (tempStart < tempEnd && (!tDic.ContainsKey(s[tempStart]) || sDic[s[tempStart]] > tDic[s[tempStart]]))
            {
                sDic[s[tempStart]]--;
                tempStart++;
            }
            // ReSharper disable once InvertIf
            if (count == tLen && tempEnd - tempStart + 1 < len)
            {
                start = tempStart;
                len = tempEnd - tempStart + 1;
            }
        }
        return len is int.MaxValue ? "" : s.Substring(start, len);
    }
}
// @lc code=end

