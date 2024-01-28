namespace Resolucoes
{
    public static class OperacoesListas
    {
        public static List<string> FilterLongStrings(List<string> originalList)
        {
            List<string> filteredList = new List<string>();

            foreach (string str in originalList)
            {
                if(str.Length >= 10)
                    filteredList.Add(str);
            }
            return filteredList;
        }
    }
}
