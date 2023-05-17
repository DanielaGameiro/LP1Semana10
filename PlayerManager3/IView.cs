using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager3
{
    public interface IView
    {
        // Todas as classes que implementam IView vão ser obrigadas a ter este método
        int MainMenu();

        void InvalidOption();

        void ShowPlayers(IEnumerable<Player> players);

        Player AskForPlayer();

        int AskForMinimumScore();
    }
}