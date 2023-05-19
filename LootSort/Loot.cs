using System;

namespace LootSort
{
    /// <summary>
    /// The Loot class should implement IComparable<Loot>
    /// and override GetHashCode() and Equals()
    /// </summary>
    public class Loot : IComparable<Loot>
    {
        /// <summary>Type of loot.</summary>
        public LootType Kind { get; }

        /// <summary>Loot description.</summary>
        public string Description { get; }

        /// <summary>Loot value.</summary>
        public float Value { get; }

        /// <summary>
        /// Create a new instance of loot.
        /// </summary>
        /// <param name="kind">Type of loot.</param>
        /// <param name="description">Loot description.</param>
        /// <param name="value">Loot value.</param>
        public Loot(LootType kind, string description, float value)
        {
            Kind = kind;
            Description = description;
            Value = value;
        }

        /// <summary>
        /// Return a nicely formatted string representing the loot instance.
        /// </summary>
        /// <returns>
        /// A nicely formatted string representing the loot instance.
        /// </returns>
        public override string ToString() =>
            $"[{Kind,15}]\t{Value:f2}\t{Description}";

        public int CompareTo(Loot other)
        {
            if (other is null) return 1;

            int compareKind = Kind.ToString().CompareTo(other.Kind.ToString());
            if (compareKind != 0)
                return compareKind;

            int compareValue = other.Value.CompareTo(Value);
            if (compareValue != 0)
                return compareValue;

            return Description.CompareTo(other.Description);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Kind, Description, Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null || GetType() != obj.GetType())
                return false;

            Loot other = (Loot)obj;
            return Kind == other.Kind &&
                   Description == other.Description && Value == other.Value;
        }
    }
}