using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    public class Player : IComparable<Player>
    {
        public string Name { get; }
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public override string ToString()
        {
            return $"{Name} ({Score})";
        }

        public int CompareTo(Player other)
        {
            if (other is null) return 1;
            return other.Score - Score;
        }
    }
}