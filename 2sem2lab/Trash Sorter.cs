using System;
using System.Text;
using _2sem1lab;

namespace _2sem1lab
{
    /// <summary>
    /// класс, содержащий метод, сортирующий мусор
    /// </summary>
    /// <typeparam name="T">тип с ограничением </typeparam>
    public class TrashSorter<T> where T : Trash
    {
        private readonly List<T> sortedTrash = [];

        /// <summary>
        /// Метод для сортировки мусора
        /// </summary>
        /// <param name="trashList"> Список мусора для сортировки </param>
        public string SortTrash(ref List<Trash> trashList)
        {
            var unsortedTrash = new List<Trash>();

            foreach (var trash in trashList)
            {
                if (trash is T typedTrash)
                    sortedTrash.Add(typedTrash);
                else
                    unsortedTrash.Add(trash);
            }
            trashList = [.. unsortedTrash];

            string result = "";
            foreach (var item in sortedTrash)
            {
                result += $"------\n{item}\n";
            }
            return result;
        }
    }
}