using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamePlayer
{
    public class Player
    {
        public PlayerType Type { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Player other = obj as Player;
            if (other is null) return false;
            if (Type.Equals(other.Type) && Name.Equals(other.Name))
                return true;
            return false;
        }
    }
}