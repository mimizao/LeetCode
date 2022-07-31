/*
 * @lc app=leetcode.cn id=30 lang=csharp
 *
 * [30] 串联所有单词的子串
 */

// @lc code=start
public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        int sLen = s.Length;
        int wordsLen = words.Length;
        int wordLen = words[0].Length;
        IList<int> result = new List<int>();
        for (int i = 0; i < wordLen && i + wordsLen * wordLen <= sLen; i++)
        {
            Dictionary<string, int> differ = new Dictionary<string, int>();
            for (int j = 0; j < wordsLen; j++)
            {
                string word = s.Substring(i + j * wordLen, wordLen);
                if (!differ.ContainsKey(word))
                {
                    differ.Add(word, 0);
                }
                differ[word]++;
            }
            foreach (string word in words)
            {
                if (!differ.ContainsKey(word))
                {
                    differ.Add(word, 0);
                }
                differ[word]--;
                if (differ[word] == 0)
                {
                    differ.Remove(word);
                }
            }
            for (int start = i; start < sLen - wordsLen * wordLen + 1; start += wordLen)
            {
                if (start != i)
                {
                    string word = s.Substring(start + (wordsLen - 1) * wordLen, wordLen);
                    if (!differ.ContainsKey(word))
                    {
                        differ.Add(word, 0);
                    }
                    differ[word]++;
                    if (differ[word] == 0)
                    {
                        differ.Remove(word);
                    }
                    word = s.Substring(start - wordLen, wordLen);
                    if (!differ.ContainsKey(word))
                    {
                        differ.Add(word, 0);
                    }
                    differ[word]--;
                    if (differ[word] == 0)
                    {
                        differ.Remove(word);
                    }
                }
                if (differ.Count == 0)
                {
                    result.Add(start);
                }
            }
        }
        return result;
    }
}
// @lc code=end

