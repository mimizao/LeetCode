// See https://aka.ms/new-console-template for more information
int n = 3;
IList<string> list = GenerateParenthesis(n);
Console.WriteLine("Hello, World!");


static IList<string> GenerateParenthesis(int n)
{
    IList<string> result = new List<string>() { };
    Generate(result, "", 0, 0, n);
    return result;
}

static void Generate(IList<string> result, string str, int leftCount, int rightCount, int n)
{
    if (leftCount > n || rightCount > n || rightCount > leftCount)
    {
        return;
    }
    if (leftCount == n && rightCount == n)
    {
        result.Add(str);
    }
    Generate(result, str + "(", leftCount + 1, rightCount, n);
    Generate(result, str + ")", leftCount, rightCount + 1, n);
    return;
}