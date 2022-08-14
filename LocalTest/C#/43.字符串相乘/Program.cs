// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");
public class Solution
{
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";
        int len1 = num1.Length; 
        int len2 = num2.Length;
        int[]arrRes = new int[len1+len2];
        for (int i = len1 - 1; i >= 0; i--)
        {
            int x = num1[i] - '0';
            for (int j = len2 - 1; j >= 0; j--)
            {
                int y = num2[j] - '0';
                arrRes[i + j + 1] += x * y;
            }
        }

        for (int i = len1 + len2 - 1; i > 0; i--)
        {
            arrRes[i - 1] += arrRes[i] / 10;
            arrRes[i] %= 10;
        }
        int index = arrRes[0] == 0 ? 1 : 0;
        StringBuilder res = new();
        while (index < len1 + len2)
        {
            res.Append(arrRes[index]);
            index++;
        }
        return res.ToString();
    }
} 