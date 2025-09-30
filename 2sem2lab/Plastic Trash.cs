using System;
using System.Text;
using _2sem1lab;

namespace _2sem1lab
{
    /// <summary>
    /// пластиковый мусор
    /// </summary>
    public class PlasticTrash : Trash
    {
        public bool CanRecycle { get; set; }

        public PlasticTrash(string name, double weight, bool canRecycle) : base(name, weight)
        {
            Name = name;
            Weight = weight;
            CanRecycle = canRecycle;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nПерерабатываемый:{(CanRecycle ? "Да" : "Нет")}";
        }
    }

}