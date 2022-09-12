Solution solution = new Solution();
string path = "/a/../../b/../c//.//";
string res = solution.SimplifyPath(path);
Console.WriteLine(res);

public class Solution
{
    public string SimplifyPath(string path)
    {
        string[] strs = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Stack<string> resStack = new Stack<string>();
        resStack.Push("/");
        for (int i = 0; i < strs.Length; i++)
        {
            if (strs[i] == "" || strs[i] == "." || (resStack.Count == 1 && strs[i] == ".."))
            {
                continue;
            }
            if (strs[i] == ".." && resStack.Count > 1)
            {
                resStack.Pop();
            }
            else
            {
                if (i == strs.Length - 1)
                {
                    resStack.Push(strs[i]);
                }
                else
                {
                    resStack.Push(strs[i] + "/");
                }
            }
        }
        while (resStack.Count > 1 && resStack.Peek() == "/")
        {
            resStack.Pop();
        }
        string res = string.Empty;
        while (resStack.Count > 0)
        {
            res = resStack.Pop() + res;
        }
        while (res[^1] == '/' && res.Length > 1)
        {
            res = res[..^1];
        }
        return res;
    }
}