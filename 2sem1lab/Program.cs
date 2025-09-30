using System;
using System.Text;

namespace variant6
{
    internal class Program
    {
        /// <summary>
        /// Контрольная работа: вариант 6
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            ///<summary>
            ///находит минимальный и максимальный элемент в имеющемся массиве, выводит элементы и их индексы
            ///</summary>
            int[] array = [-5, 3, 7, 1, 22, 2, 8];
            int minElement = array[0];
            int maxElement = array[0];
            int minElementIndex = 0;
            int maxElementIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minElement)
                {
                    minElement = array[i];
                    minElementIndex = i;
                }

                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                    maxElementIndex = i;
                }
            }
            Console.WriteLine($"Мин. элемент и его индекс: {minElement}, {minElementIndex}\nМакс. элемент и его индекс:{maxElement}, {maxElementIndex}");
            Console.ReadKey();
            Console.Clear();

            ///<summary>
            ///Метод, который принимает два параметра типа int по ссылке и меняет их местами
            /// </summary>
            Console.WriteLine("Введите два целочисленных значения:");
            int a = GotNumber();
            int b = GotNumber();
            Console.WriteLine($"До обмена: a = {a}, b = {b}");
            Swap(ref a, ref b);
            static void Swap(ref int x, ref int y)
            {
                int temp = x;
                x = y;
                y = temp;
            }
            static int GotNumber()
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        return number;
                    }
                    Console.WriteLine("Ошибка. Пожалуйста, введите число повторно:");
                }
            }

            Console.WriteLine($"После обмена: a = {a}, b = {b}");
            Console.ReadKey();
            Console.Clear();


            ///<summary>
            ///приложение-калькулятор, которое выполняет основные арифметические операции с двумя числами.
            ///gрограмма должна обрабатывать возможные ошибки (в т.ч. деление на нуль)
            /// </summary>
            Console.WriteLine("Введите первое число:");
            var num1 = GetNumber();
            Console.WriteLine("Введите второе число:");
            var num2 = GetNumber();
            Console.WriteLine("Выберите операцию: +, -, *, /");
            string operation = Console.ReadLine();
            double result;
            try
            {
                result = PerformOperation(num1, num2, operation);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка");
            }
        }
        /// <summary>
        /// методы для калькулятора: ввести число с проверкой и выбор операции
        /// </summary>
        /// <returns></returns>
        static double GetNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                {
                    return number;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка. Пожалуйста, введите число повторно:");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static double PerformOperation(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return num1 + num2;
                
                case "-":
                    return num1 - num2;
                
                case "*":
                    return num1 * num2;
                
                case "/":
                    if (num2 != 0) return num1 / num2;
                    
                    throw new DivideByZeroException("Деление на ноль недопустимо");
                
                default:
                    throw new InvalidOperationException("Недопустимая операция");
            }
        }

    }
}