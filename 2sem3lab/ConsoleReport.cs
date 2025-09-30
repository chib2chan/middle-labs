using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _2sem2lab;

namespace _2sem2lab
{
    public class ConsoleReport
    {
        /// <summary>
        /// Метод для генерации отчёта (возвращает особу строку с данными об объектах)
        /// </summary>
        /// <typeparam name="T"> тип (без ограничений) </typeparam>
        /// <param name="collection"> коллекция, в которой находятся характеристики объекта </param>
        /// <param name="properties"> какие свойства имеются у коллекции </param>
        /// <param name="format"> горизонтально/вертикально/никак </param>
        /// <returns></returns>
        public static string GenerateReport<T> (IEnumerable<T> collection, IEnumerable<string> properties, string format)
        {
            string result = "";

            //строка, которая получает свойства объекта через рефлексию (скрывая атрибут "риск")
            //
            var propertyInfo = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(HiddenAttribute), false).Length == 0).ToList();
            
            //строка, которая получает свойства объекта через рефлексию (вместе с атрибутом "риск")
            //var propertyInfo = typeof(T).GetProperties().ToList();

            switch (format)
            {
                case "vertical":

                    foreach (var item in collection)
                    {
                        //рефлексия: какой тип был у переменной (дом, машина, человек или зверек)
                        result += $"-----\nType:\t\t{typeof(T).Name}\n";

                        foreach (var property in propertyInfo)
                        {
                            //рефлексия: какое значение у предмета из коллекции (например, указывает, какие были год у автомобиля, улица у дома и т.п.)
                            result += $"{property.Name}:\t\t{property.GetValue(item)}\n";
                        }
                    }

                break;

                case "horizontal":

                    foreach (var item in collection)
                    {
                        //рефлексия: какой тип был у переменной (дом, машина, человек или зверек)
                        result += $"\nType: {typeof(T).Name}\t";

                        foreach (var property in propertyInfo)
                        {
                            //рефлексия: какое значение у предмета из коллекции (например, указывает, какие были год у автомобиля, улица у дома и т.п.)
                            result += $"\t|\t{property.Name}: {property.GetValue(item)}\t";
                        }
                    }

                break;

                default:
                    result += "Didn't find any information";

                break;
            }
            
            return result;
        }
    }
}