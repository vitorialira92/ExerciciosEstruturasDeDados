
namespace Resolucoes
{
    public static class OperacoesPilha
    {
        public static bool IsExpressionBalanced(string expression)
        {
            Stack<char> s = new Stack<char>();
            foreach (char c in expression)
            {
                switch (c)
                {
                    case '(': s.Push(c); break;
                    case '[': s.Push(c); break;
                    case '{': s.Push(c); break;
                    default:
                        if (c == ')' || c == '}' || c == ']')
                        {
                            if(s.Count > 0)
                            {
                                char c2 = s.Pop();
                                if (c == ')' && c2 != '(')
                                    return false;
                                if (c == ']' && c2 != '[')
                                    return false;
                                if (c == '}' && c2 != '{')
                                    return false;
                            }
                            else
                                return false;
                        }
                        
                        break;
                }
            }
            return s.Count == 0;
        }
    }
}
