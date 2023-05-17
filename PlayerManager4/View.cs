using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    public class View : IView
    {
        private Controller controller;
        //private List<Player> list;
        public View(Controller controller) //List<Player> list)
        {
            this.controller = controller;
            //this.list = list;
        }

        public int MainMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----");
            Console.WriteLine("1. Inserir jogador");
            Console.WriteLine("2. Listar jogadores");
            Console.WriteLine("3. Listar jogadores com o melhor score");
            Console.WriteLine("0. Sair");
            Console.WriteLine("");
            Console.Write("> ");

            return int.Parse(Console.ReadLine());
        }

        public PlayerOrder AskPlayerOrder()
        {
            Console.WriteLine("Ordem de jogadores");
            Console.WriteLine("------------------");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByScore}. Ordem por score");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByName}. Ordem por nome");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByNameReverse}. Ordem por nome (inverso)");
            Console.WriteLine("");
            Console.Write("> ");

            return (PlayerOrder)int.Parse(Console.ReadLine());
        }

        public void InvalidOption()
        {
            Console.WriteLine("\nOpção invalida! Pressiona qualquer tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public void ShowPlayers(IEnumerable<Player> players)
        {
            Console.WriteLine();
            foreach (Player p in players)
            {
                Console.WriteLine($"-> {p}");
            }
            Console.WriteLine("\nPressiona qualquer tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public Player AskForPlayer()
        {
            string name;
            int score;

            Console.WriteLine();
            Console.WriteLine("Inserir os dados do jogador");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.Write("Nome > ");
            name = Console.ReadLine();
            Console.Write("Score > ");
            score = int.Parse(Console.ReadLine());

            return new Player(name, score);
        }

        public int AskForMinimumScore()
        {
            Console.WriteLine();
            Console.Write("Score mínimo? > ");
            return int.Parse(Console.ReadLine());
        }
    }
}