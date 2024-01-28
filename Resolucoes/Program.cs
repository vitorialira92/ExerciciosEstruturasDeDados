namespace Resolucoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Casos de teste");
            Console.WriteLine("Exercício 1: Escreva uma função que receba uma lista de strings e retorne uma \n" +
                "nova lista contendo somente strings que contenham 10 ou mais caracteres\n");
            var input = new List<string>{
                  "Idiossincrasia",
                  "Ambivalente",
                  "Quimérica",
                  "Perpendicular",
                  "Efêmero",
                  "Pletora",
                  "Obnubilado",
                  "Xilografia",
                  "Quixote",
                  "Inefável"
               };
            Console.WriteLine("Resultado:");

            int count = 0;

            foreach (string s in OperacoesListas.FilterLongStrings(input))
            {
                Console.Write($"{s} | ");
                count++;
            }
            Console.WriteLine($"\nEsperado: 5 itens | Resultado: {count} | Passed:{count == 5}");

            Console.WriteLine("\n\nExercício 2: Escreva uma função que receba uma expressão mátemática como entrada e verifique se a expressão está balanceada. " +
                "\nUma expressão está balanceada se para cada parênteses de abertura, existe um parênteses de fechamento correspondente.\n");

            string balanceada = "(2+1)*80/(7-[√9 + {4² * 0}])";
            string naoBalanceada = "([{35 - 2} + 5*3} + 0 / 15) - [3 + 5³] * 11)";

            bool primeiroTeste = OperacoesPilha.IsExpressionBalanced(balanceada);

            Console.WriteLine($"Expressão: {balanceada}\nResultado esperado: true | Resultado: {primeiroTeste} | Passed: {primeiroTeste == true}");

            bool segundoTeste = OperacoesPilha.IsExpressionBalanced(naoBalanceada);

            Console.WriteLine($"Expressão: {naoBalanceada}\nResultado esperado: false | Resultado: {segundoTeste} | Passed: {segundoTeste == false}");

            Console.WriteLine("\n\nExercício 3: Escreva uma função que simule o jogo de batata quente. \r\n" +
                "Nesse jogo, jogadores passam a batata quente por um círculo até ela explodir. O jogador que estiver com a batata quando explodir está fora do jogo.\n");

            List<(int player, int roundLeft)> lista = OperacoesFila.PlayBatataQuente(90);
            foreach(var item in lista)
            {
                if(item.player == 0)
                    Console.WriteLine($"JOGO COM {item.roundLeft} PASSES POR ROUND");
                else if(item.roundLeft != 0)
                    Console.WriteLine($"JOGADOR {item.player} SAIU NO ROUND {item.roundLeft}");
                else
                    Console.WriteLine($"JOGADOR {item.player} FOI O GANHADOR\n");
            }


            Console.WriteLine("\n\nExercício 4: *Utilizadno um dicionário, crie um contador de palavras.*\r\n" +
                "O programa deve receber como entrada um texto e, usando dicionário, contar quantas ocorrências de cada palavra acontecem nesse texto\n");

            var inputText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nulla auctor porta velit a tincidunt. Nam efficitur iaculis placerat. " +
                "Aenean lectus dui, sollicitudin id rhoncus tristique, aliquet sed quam. " +
                "Phasellus blandit magna at elementum consequat. Nam vitae nunc vehicula, blandit felis a, " +
                "placerat augue. Quisque bibendum a ipsum at scelerisque. Duis molestie turpis quis orci vehicula aliquam. " +
                "Duis non elementum erat. Phasellus et dui odio. Nunc vitae leo sem. Curabitur nec enim id mi aliquet commodo " +
                "at et sapien. Fusce sit amet nisi elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. " +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis vitae dolor " +
                "at sem ultrices euismod. Morbi aliquet, felis et mattis congue, justo nunc pharetra lectus, a lobortis mauris " +
                "eros et nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas " +
                "sollicitudin posuere nibh malesuada suscipit. Nam a sapien ex. Donec mollis justo est, quis tempus mi pharetra at. " +
                "ras fringilla enim eu egestas scelerisque. Praesent tristique imperdiet consectetur. Donec interdum pulvinar nulla vel pharetra. " +
                "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aliquam interdum finibus mi, " +
                "in tempus lorem. Cras diam magna, viverra vitae ante eget, scelerisque sodales velit. " +
                "Aliquam erat volutpat. Mauris consectetur sapien mi, vel euismod quam consectetur id.";

            Dictionary<string, int> dic = OperacoesDicionario.CountWords(inputText);

            foreach(var item in dic)
            {
                Console.WriteLine($"A palavra {item.Key} apareceu {item.Value} vezes no texto");
            }
        }
    }
}
