// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool IsValid(string s)
{
    int len = s.Length;
    if (len % 2 != 0)
    {
        return false;
    }
    Stack<char> chars = new();
    for (int i = 0; i < len; i++)
    {
        char c = s[i];
        if (c == '(' || c == '[' || c == '{')
        {
            chars.Push(c);
        }
        else if (chars.Count == 0 || (c == ')' && chars.Pop() != '(' || (c == ']' && chars.Pop() != '[') || (c == '}' && chars.Pop() != '{')))
        {
            return false;
        }
    }
    return chars.Count == 0;
}