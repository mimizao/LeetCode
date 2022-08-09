// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

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
