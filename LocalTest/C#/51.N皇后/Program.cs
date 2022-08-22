// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using System.Text;

Solution solution = new Solution();
int n = 4;
var res = solution.SolveNQueens(n);
Console.WriteLine("Hello, World!");

public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        Stack<int> path = new Stack<int>();
        Stack<bool[,]> flagStack = new Stack<bool[,]>();
        IList<IList<string>> res = new List<IList<string>>();
        GetRes(path, flagStack, res, n);
        return res;
    }

    private void GetRes(Stack<int> path, Stack<bool[,]> flagStack, IList<IList<string>> res, int n)
    {
        if (path.Count == n)
        {
            List<int> tempRes = new(path);
            tempRes.Reverse();
            IList<string> tempStrRes = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string str = "";
                for (int j = 0; j < n; j++)
                {
                    if (j == tempRes[i])
                    {
                        str += "Q";
                    }
                    else
                    {
                        str += ".";
                    }
                }

                tempStrRes.Add(str);
            }

            res.Add(tempStrRes);
            return;
        }

        bool[,] oldFlags = new bool[n, n];
        if (flagStack.Count != 0)
        {
            oldFlags = flagStack.Peek();
        }

        for (int i = 0; i < n; i++)
        {
            if (oldFlags[path.Count, i])
            {
                continue;
            }

            path.Push(i);
            bool[,] newFlags = GetFlagsFromPath(path, n);
            flagStack.Push(newFlags);
            GetRes(path, flagStack, res, n);
            path.Pop();
            flagStack.Pop();
        }

        return;
    }

    private bool[,] GetFlagsFromPath(Stack<int> path, int n)
    {
        bool[,] flags = new bool[n, n];
        List<int> tempRes = new(path);
        tempRes.Reverse();
        for (int i = 0; i < tempRes.Count; i++)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == i || col == tempRes[i] || row - i == col - tempRes[i] || row - i == tempRes[i] - col)
                    {
                        flags[row, col] = true;
                    }
                }
            }
        }

        return flags;
    }
}