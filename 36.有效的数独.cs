/*
 * @lc app=leetcode.cn id=36 lang=csharp
 *
 * [36] 有效的数独
 */

// @lc code=start
public class Solution {
public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        char[] charsCol = new char[9];
        char[] charsRow = new char[9];
        List<char> charsSudoku0 = new();
        List<char> charsSudoku1 = new();
        List<char> charsSudoku2 = new();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                charsCol[j] = board[i][j];
                charsRow[j] = board[j][i];
                if (j / 3 == 0)
                {
                    if ((board[i][j] != '.') && (charsSudoku0.Contains(board[i][j])))
                    {
                        return false;
                    }
                    else
                    {
                        charsSudoku0.Add(board[i][j]);
                    }
                }
                else if (j / 3 == 1)
                {
                    if (board[i][j] != '.' && charsSudoku1.Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        charsSudoku1.Add(board[i][j]);
                    }
                }
                else
                {
                    if (board[i][j] != '.' && charsSudoku2.Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        charsSudoku2.Add(board[i][j]);
                    }
                }
            }
            if (!IsValidChars(charsRow) || !IsValidChars(charsCol))
            {
                return false;
            }
            if (i % 3 == 2)
            {
                charsSudoku0.Clear();
                charsSudoku1.Clear();
                charsSudoku2.Clear();
            }
        }
        return true;
    }

    public bool IsValidChars(char[] chars)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != '.')
            {
                if (charCount.ContainsKey(chars[i]))
                {
                    return false;
                }
                else
                {
                    charCount[chars[i]] = 1;
                }
            }
        }
        return true;
    }
}
}
// @lc code=end

