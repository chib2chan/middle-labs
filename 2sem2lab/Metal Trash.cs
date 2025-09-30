using System;
using System.Text;
using _2sem1lab;

namespace _2sem1lab
{
    /// <summary>
    /// металлический мусор
    /// </summary>
    public class MetalTrash : Trash
    {
        public string MetalType { get; set; }

        public MetalTrash(string name, double weight, string metalType) : base(name, weight)
        {
            Name = name;
            Weight = weight;
            MetalType = metalType;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nВид металла:{MetalType}";
        }
    }
}