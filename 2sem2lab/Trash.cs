using System;
using System.Text;
using _2sem1lab;

namespace _2sem1lab
{
    /// <summary>
    /// класс для всех типов мусора
    /// </summary>
    public abstract class Trash(string name, double weight)
    {
        public string Name { get; set; } = name;
        public double Weight { get; set; } = weight;

        public override string ToString()
        {
            return $"Наименование:{Name}\nМасса:{Weight}кг";
        }
    }
}