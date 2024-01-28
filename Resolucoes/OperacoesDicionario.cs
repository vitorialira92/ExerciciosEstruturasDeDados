namespace Resolucoes
{
    public static class OperacoesDicionario
    {
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            // Usar uma lista chars evita duplicações na lista como ter que considerar espaços antes e depois do caracter
            char[] sep = [' ', ',', ';', '!', '?', ',', '.', ':', '-'];

            // Não precisa ser uma lista para que você consiga iterar sobre os elementos.
            var words = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

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
