﻿using System;
using System.Collections.Generic;

namespace SamePlayer
{
    class Program
    {
        static void Main()
        {
            ISet<Player> setOfPlayers = new HashSet<Player>();

            setOfPlayers.Add(new Player() { 
                Name = "Ana", Type = PlayerType.Tank });
            setOfPlayers.Add(new Player() { 
                Name = "Paulo", Type = PlayerType.Slayer });
            setOfPlayers.Add(new Player() { 
                Name = "Ana", Type = PlayerType.Tank });

            foreach(Player p in setOfPlayers)
                Console.WriteLine($"{p.Name} is a {p.Type}.");
        }
    }
}