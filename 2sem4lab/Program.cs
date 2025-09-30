using System;
using System.Collections.Generic;
using _2sem3lab;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2sem3lab
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the client's name:");
            string clientName = InputSymbols(Console.ReadLine());
            Random random = new();
            double clientBalance = random.Next(100, 10001);
            Client clientOfCoffeeHouse = new(clientName, clientBalance);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Welcome to the Yellow-Yellow, {clientOfCoffeeHouse.Name}! You can spend here ALL YOUR MONEY ({clientOfCoffeeHouse.Balance}R)!!!");
            Console.ForegroundColor = ConsoleColor.White;

            CoffeeHouse coffeeHouse = new()
            {
                Menu =
                [
                    new Food("Latte", 179),
                    new Food("Choco cake", 199),
                    new Food("Bubble tea", 299),
                    new Food("Salad", 249),
                    new Food("Americano", 179),
                    new Food("A bottle of water", 49)
                ]
            };

            OrderedFood selectFoodDelegate = SelectFoodFromMenu;// экземпляра делегата, через который потом будет вызван метод
            List<Food> selectedFoods = selectFoodDelegate(coffeeHouse.Menu);// вызов через делегат
            //List<Food> selectedFoods = SelectFoodFromMenu(coffeeHouse.Menu); //вызов напрямую

            Courier courierFinn = new() { Name = "Finn from St. Petersburg", Rating = 0.2, IsAvailable = true };
            Courier courierIvan = new() { Name = "Vin Diesel", Rating = 0.9, IsAvailable = true };
            Courier courierHussein = new() { Name = "Usain Bolt", Rating = 1, IsAvailable = true };

            DeliveryHandler CourierHandler = coffeeHouse.CourierRegister; //экземпляр делегата, через который потом будет вызван метод
            CourierHandler(courierFinn); //вызов через делегат
            CourierHandler(courierIvan);
            CourierHandler(courierHussein);
            //coffeeHouse.CourierRegister(courierFinn); //вызов напрямую
            //coffeeHouse.CourierRegister(courierIvan); 
            //coffeeHouse.CourierRegister(courierHussein);

            Console.WriteLine("Do you want delivery? 1. yes\t2. no");
            string deliveryChoice = Console.ReadLine().ToLower();
            bool isDelivery = deliveryChoice == "yes";

            CreateOrder makeClientOrder = coffeeHouse.MakeOrder; // Создаем экземпляр делегата
            string result = makeClientOrder(clientOfCoffeeHouse,
                selectedFoods, isDelivery, ProcessPayment); //вызов делегата и присвоение переменной его значения
            Console.WriteLine(result);

            //Console.WriteLine(coffeeHouse.MakeOrder(clientOfCoffeeHouse,
            //selectedFoods, isDelivery, (client, waiter, e) => ProcessPayment(client, waiter, e)));
            //строка выше - вызов делегата напрямую
            Console.ReadLine();
        }

        /// <summary>
        /// выбор блюд из меню
        /// </summary>
        /// <param name="menu">какие позиции существуют</param>
        /// <returns>список блюд из заказа</returns>
        static List<Food> SelectFoodFromMenu(List<Food> menu)
        {
            Console.WriteLine("Available menu:");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i].Name} - {menu[i].Price}Rub");
            }

            Console.WriteLine("Enter the numbers of dishes you want to order (separated by spaces):");

            List<int> selectedIndices = [];

            while (true)
            {
                string input = InputSymbols(Console.ReadLine());

                if (input.All(c => char.IsDigit(c) || c == ' '))
                {
                    try
                    {
                        selectedIndices = [.. input.Split(' ').Select(int.Parse)];
                        if (selectedIndices.All(index => index > 0 && index <= menu.Count)) break;
                        else Console.WriteLine("You entered incorrect positions.");
                        
                    }
                    catch
                    {
                        Console.WriteLine("You entered invalid numbers.");
                    }
                }
                else
                {
                    Console.WriteLine("You entered invalid characters. Use numbers and spaces only.");
                }
            }

            List<Food> selectedFoods = [];
            foreach (int index in selectedIndices)
            {
                selectedFoods.Add(menu[index - 1]);
            }

            return selectedFoods;
        }

        /// <summary>
        /// метод, выводящий "оплата в процессе"
        /// </summary>
        static void ProcessPayment(Client client, CoffeeHouse waiter, OrderEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Payment is processing...\n");
            Thread.Sleep(5000);
            Console.WriteLine(client.PayCheck(waiter, e));
        }

        /// <summary>
        /// метод для проверки строки на пустоту
        /// </summary>
        /// <param name="s">введенная пользователем строка</param>
        public static string InputSymbols(string s)
        {
            if (!string.IsNullOrEmpty(s)) return s;
            else
            {
                Console.WriteLine("You haven't entered anything. Enter again:");
                s = Console.ReadLine();
            }
            return s;
        }
    }
}