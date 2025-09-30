using System;
using System.Text;
using _2sem1lab;

namespace _2sem1lab
{
    /// <summary>
    /// органический мусор
    /// </summary>
    public class OrganicTrash : Trash
    {
        public int DamagePercent { get; set; }

        public OrganicTrash(string name, double weight, int damagePercent) : base(name, weight)
        {
            Name = name;
            Weight = weight;
            DamagePercent = damagePercent;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nУровень поврежденности: {DamagePercent}%";
        }
    }
}