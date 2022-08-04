// See https://aka.ms/new-console-template for more information
char[][] board = { new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' }, new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' }, new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' }, new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' }, new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' }, new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' }, new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' }, new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' }, new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
bool res = Solution.IsValidSudoku(board);
Console.WriteLine(res);


public class Solution
{
    public static bool IsValidSudoku(char[][] board)
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

    public static bool IsValidChars(char[] chars)
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