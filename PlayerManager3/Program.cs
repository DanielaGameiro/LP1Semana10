using System;
using System.Collections.Generic;

namespace PlayerManager3
{
    public class Program
    {
        private static void Main()
        {
            // Lista de jogadores é o nosso modelo
            List<Player> list = new List<Player>()
            { new Player("Daniela", 100), new Player("Luís", 100) };

            // Criar controlador
            Controller controller = new Controller(list);

            // Criar view
            IView view = new View(controller); //, list);

            // Começar programa
            controller.Run(view);
        }
    }
}
