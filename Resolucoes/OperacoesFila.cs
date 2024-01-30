namespace Resolucoes
{
    public static class OperacoesFila
    {
        public static GameResults PlayBatataQuente(int playersCount)
        {
            GameResults results = new GameResults();
            Queue<int> playersQueue = new Queue<int>();
            
            for(int i = 0; i < playersCount; i++)
                playersQueue.Enqueue(i + 1);

            while(playersQueue.Count > 1)
            {
                results.Turns++;
                int rounds = GetRoundsNumber();
                for (int i = 0; i < rounds; i++)
                {
                    int topo = playersQueue.Dequeue();
                    playersQueue.Enqueue(topo);
                }
                var loserPlayer = playersQueue.Dequeue();
                results.MidTurnResults.Add(new MidTurnResult($"Player {loserPlayer}",results.Turns));
            }

            results.Winner = $"Player {playersQueue.Dequeue()}";

            return results;
        }
        public static int GetRoundsNumber()
        {
            return new Random().Next(1, 101);
        }
    }

    public class GameResults
    {
        public int Turns { get; internal set; }
        public List<MidTurnResult> MidTurnResults { get; } = new List<MidTurnResult>();
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
