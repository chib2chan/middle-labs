using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using _2sem2lab;

class Program
{
    static void Main()
    {
        var cars = new List<Car>
        {
            new Car { Model = "Toyota", Year = 2018, Color = "Black", Risk = 0.5 },
            new Car { Model = "Zhiguli", Year = 2010, Color = "Cherry", Risk = 1 },
            new Car { Model = "BMW", Year = 2022, Color = "Magenta", Risk = 0.2 }
        };

        var people = new List<People>
        {
            new People { Name = "Igor", Age = 18, HasWork = true, Risk = 0.5 },
            new People { Name = "Rostidlav", Age = 45, HasWork = true, Risk = 0.5 },
            new People { Name = "Ludmila", Age = 22, HasWork = false, Risk = 0.5 }
        };

        var houses = new List<House>
        {
            new House { Address = "Lenina street", Floor = 2, HasGarage = true, Risk = 0.3 },
            new House { Address = "Mira avenue", Floor = 1, HasGarage = false, Risk = 0.6 },
            new House { Address = "Kirenskogo street", Floor = 12, Risk = 0.3}
        };

        var animal = new List<Animal>
        {
            new Animal { Species = "Rat", Name = "Kris", Weight = 0.53, Risk = 0.5 },
            new Animal { Species = "Rat", Name = "Kristina", Weight = 0.43, Risk = 0.5 },
            new Animal { Species = "Rat", Name = "Krisuk", Weight = 0.33, Risk = 1 }
        };

        var report = new ConsoleReport();

        Console.WriteLine("Cars' report:");

        var Cars = ConsoleReport.GenerateReport(cars, new[] { "Risk" }, "horizontal");
        Console.WriteLine(Cars);

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Houses' report:");

        var Houses = ConsoleReport.GenerateReport(houses, new[] { "Risk" }, "vertical");
        Console.WriteLine(Houses);

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("People report:");

        var People = ConsoleReport.GenerateReport(people, new[] { "Risk" }, "horizontal");
        Console.WriteLine(People);

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Animals' report:");

        var Animal = ConsoleReport.GenerateReport(animal, new[] { "Risk" }, "vertical");
        Console.WriteLine(Animal);
    }
}