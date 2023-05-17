using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    public class Controller
    {
        private List<Player> list;
        private IView view;
        private IComparer<Player> compareByName;
        private IComparer<Player> compareByNameReverse;

        public Controller(List<Player> list)
        {
            this.list = list;

            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
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
                        SortPlayers();
                        view.ShowPlayers(list);
                        break;
                    case 3:
                        SortPlayers();
                        ShowPlayersWithScore();
                        break;
                    default:
                        view.InvalidOption();
                        break;
                }
            }
            while (input != 0);
        }

        private void SortPlayers()
        {
            PlayerOrder ord = view.AskPlayerOrder();
            switch (ord)
            {
                case PlayerOrder.ByScore:
                    list.Sort();
                    break;
                case PlayerOrder.ByName:
                    list.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    list.Sort(compareByNameReverse);
                    break;
            }
        }

        private void InsertPlayer()
        {
            // Pedir à view um jogador
            Player p = view.AskForPlayer();

            // Inserir o jogador na lista de jogadores
            list.Add(p);
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