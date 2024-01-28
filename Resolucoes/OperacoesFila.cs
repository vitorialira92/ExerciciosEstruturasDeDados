namespace Resolucoes
{
    public static class OperacoesFila
    {
        public static List<(int player, int roundLeft)> PlayBatataQuente(int playersCount)
        {
            List<(int player, int roundLeft)> relatorio = new List<(int, int)>();

            

            int rounds = GetRoundsNumber();
            relatorio.Add((0, rounds));
            Queue<int> playersQueue = new Queue<int>();
            
            for(int i = 0; i < playersCount; i++)
            {
                playersQueue.Enqueue(i + 1);
            }

            int count = 1;

            while(playersQueue.Count > 1)
            {
                for (int i = 0; i < rounds; i++)
                {
                    int topo = playersQueue.Dequeue();
                    playersQueue.Enqueue(topo);
                }
                relatorio.Add((playersQueue.Dequeue(), count));
                count++;
            }
            relatorio.Add((playersQueue.Dequeue(), 0));

            return relatorio;
        }

        public static GameResults PlayBatataQuente2(int playersCount)
        {
            GameResults relatorio = new();
            Queue<int> playersQueue = new();

            for (int i = 0; i < playersCount; i++)
                playersQueue.Enqueue(i + 1);

            while (playersQueue.Count > 1)
            {
                relatorio.Turns++;
                // O número de passes é diferente em cada round
                int rounds = GetRoundsNumber();
                for (int i = 0; i < rounds; i++)
                {
                    int topo = playersQueue.Dequeue();
                    playersQueue.Enqueue(topo);
                }
                var loserPlayer = playersQueue.Dequeue();
                // Inclui um registro informando o jogador que perdeu naquele turno
                relatorio.MidTurnResults.Add(new MidTurnResult($"Player {loserPlayer}", relatorio.Turns));
            }

            relatorio.Winner = $"Player {playersQueue.Dequeue()}";

            return relatorio;
        }

        public static int GetRoundsNumber()
        {
            return new Random().Next(1, 101);
        }

        public class GameResults
        {
            public int Turns { get; internal set; }
            public List<MidTurnResult> MidTurnResults { get; } = new List<MidTurnResult> ();
            public string Winner { get; internal set; }
        }
        public class MidTurnResult
        {
            public string PlayerOut { get; }
            public int Turn { get; }

            public MidTurnResult(string playerOut, int turn)
            {
                PlayerOut = playerOut;
                Turn = turn;
            }
        }
    }
}
