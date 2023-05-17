using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager3
{
    public class Controller
    {
        private List<Player> list;
        private IView view;
        public Controller(List<Player> list)
        {
            this.list = list;
            list.Sort();
        }

        public void Run(IView view)
        {
            int input;
            this.view = view;
            do
            {
                // Melhor fazer isto com enum
                // 1 -> Inserir jogador
                // 2 -> Listar jogadores
                // 3 -> Listar jogadores com score > x
                // 0 -> Exit
                input = view.MainMenu();

                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        InsertPlayer();
                        break;
                    case 2:
                        view.ShowPlayers(list);
                        break;
                    case 3:
                        ShowPlayersWithScore();
                        break;
                    default:
                        view.InvalidOption();
                        break;
                }
            }
            while (input != 0);
        }

        private void InsertPlayer()
        {
            // Pedir à view um jogador
            Player p = view.AskForPlayer();

            // Inserir o jogador na lista de jogadores
            list.Add(p);

            // Ordenar lista
            list.Sort();
        }

        private void ShowPlayersWithScore()
        {
            // Perguntar à view qual é o score mínimo
            int minScore = view.AskForMinimumScore();

            // Criar coleção com os jogadores com o score mínimo
            IEnumerable<Player> players =
                GetPlayersWithScoreGreaterThan(minScore);

            // Pedir à view para mostrar os jogadores
            view.ShowPlayers(players);
        }

        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player p in list)
            {
                if (p.Score > minScore)
                    yield return p;      // ciclo yield implementado
            }
        }
    }
}