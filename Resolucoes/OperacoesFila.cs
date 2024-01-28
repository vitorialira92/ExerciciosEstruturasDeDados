using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static int GetRoundsNumber()
        {
            return new Random().Next(1, 101);
        }
    }
}
