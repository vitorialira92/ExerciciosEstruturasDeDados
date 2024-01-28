using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolucoes
{
    public static class OperacoesDicionario
    {
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            string[] sep = new string[] { " ", ", ", "; ", "! ", "? ", ",", ".", ";",  "!", "?"};

            List<string> words = text.Split(sep, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var w in words)
            {
                if(values.TryGetValue(w.ToLower(), out int count))
                {
                    values[w] = ++count;
                }
                else
                {
                    values.Add(w.ToLower(), 1);
                }
            }

            return values;
        }
    }
}
