using System;
using System.Text;
using _2sem1lab;

namespace _2sem1lab
{
    class Program
    {
        static void Main()
        {
            var allTrash = new List<Trash>
            {
                new OrganicTrash("Яблоко", 0.5, 80),
                new OrganicTrash("Банан", 0.3, 70),
                new OrganicTrash("Бумага", 0.01, 20),
                new MetalTrash("Гаечный ключ", 10.0, "Железо"),
                new MetalTrash("Алюминиевая банка", 0.2, "Алюминий"),
                new MetalTrash("Кастрюлька", 0.5, "Сталь"),
                new PlasticTrash("Пластиковая бутылка", 0.1, true),
                new PlasticTrash("Пакет из пятерочки", 0.05, false),
                new PlasticTrash("Баночка из-под шампуня", 0.05, true),
                new ToxicTrash("Пакетик с ГХК", 0.01, "Высокий"),
                new ToxicTrash("батарейка", 0.08, "Средний"),
                new ToxicTrash("Медицинские инструменты", 0.3, "Низкий")
            };

            TrashSorter<OrganicTrash> organicSorter = new();
            TrashSorter<MetalTrash> metalSorter = new();
            TrashSorter<PlasticTrash> plasticSorter = new();
            TrashSorter<ToxicTrash> toxicSorter = new();

            Console.WriteLine("Органический тип мусора");
            Console.WriteLine(organicSorter.SortTrash(ref allTrash));

            Console.WriteLine("Металлический тип мусора");
            Console.WriteLine(metalSorter.SortTrash(ref allTrash));

            Console.WriteLine("Пластиковый тип мусора");
            Console.WriteLine(plasticSorter.SortTrash(ref allTrash));

            Console.WriteLine("Опасный тип мусора");
            Console.WriteLine(toxicSorter.SortTrash(ref allTrash));
        }
    }
}