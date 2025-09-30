using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using _2sem4lab;

namespace _2sem4lab
{
    class Program
    {
        /// <summary>
        /// Это приложение, но для официанта)
        /// </summary>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //все для анимешников
            ChangeColor("Добро пожаловать в ресторан \"ネコタリア\"! Готовы сделать заказ?", ConsoleColor.Magenta);
            ChangeColor("                            \"Nekotalia\"", ConsoleColor.DarkGray);

            Restaurant restaurant = new();
            restaurant.RegisterStaff();
            while (true)
            {
                ChangeColor("Выберите одно из действий ниже:", ConsoleColor.DarkYellow);
                Console.WriteLine("\n1.\tСделать заказ" +
                                  "\n2.\tПоказать самые популярные блюда" +
                                  "\n3.\tОтчитаться о работе официантов" +
                                  "\n4.\tОтчитаться о заказах пользователей" +
                                  "\n5.\tПосмотреть старые заказы (for admin.)" +
                                  "\n6.\tВыход");
                int clientAnswer = ConverterInt(Console.ReadLine());

                switch (clientAnswer)
                {
                    case 1:
                        restaurant.MakeOrder();
                        break;
                    case 2:
                        Console.WriteLine(restaurant.ShowPopularDishes());
                        break;
                    case 3:
                        Console.WriteLine(restaurant.ShowHardworkingWaiters());
                        break;
                    case 4:
                        Console.WriteLine(restaurant.ShowReportAboutCustomers());
                        break;
                    case 5:
                        Console.WriteLine(restaurant.OrdersInfo());
                        break;
                    case 6:
                        ChangeColor("さようなら!", ConsoleColor.Magenta);
                        ChangeColor("До свидания!", ConsoleColor.DarkGray);
                        return;
                    default:
                        ChangeColor("Неверный ввод. Попробуйте ещё раз", ConsoleColor.Red);
                        break;
                }
                ChangeColor("Введите enter, чтобы вернуться на главный экран...", ConsoleColor.DarkGray);
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Метод для проверки строки на пустоту
        /// </summary>
        /// <param name="s">Введенная пользователем строка</param>
        public static string InputSymbols(string s)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(s)) return s;
                else
                {
                    Console.Clear();
                    ChangeColor("You entered invalid numbers. Enter something:", ConsoleColor.Red);
                    s = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Метод, переводящий string в int
        /// </summary>
        /// <param name="input">Строка, переводимая в число</param>
        /// <returns></returns>
        public static int ConverterInt(string input)
        {
            input = InputSymbols(input);
            while (true)
            {
                if (int.TryParse(input, out int number))
                {
                    try
                    {
                        int newNumber = number;
                        return newNumber;
                    }
                    catch
                    {
                        ChangeColor("You entered invalid numbers. Enter 'int' symbols", ConsoleColor.Red);
                    }
                }
            }
        }

        /// <summary>
        /// Метод для вывода строки с указанным цветом текста
        /// </summary>
        /// <param name="text">Текст для вывода</param>
        /// <param name="color">Цвет текста</param>
        public static void ChangeColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}