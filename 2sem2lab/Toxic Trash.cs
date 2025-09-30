using System;
using System.Text;
using _2sem1lab;

namespace _2sem1lab
{
    /// <summary>
    /// токсичный мусор
    /// </summary>
    public class ToxicTrash : Trash
    {
        public string HazardLevel { get; set; }

        public ToxicTrash(string name, double weight, string hazardLevel) : base(name, weight)
        {
            Name = name;
            Weight = weight;
            HazardLevel = hazardLevel;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nУровень загрязненности:{HazardLevel}";
        }
    }
}