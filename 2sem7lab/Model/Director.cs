using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MovieRating;

namespace MovieRating.Model
{
    /// <summary>
    /// класс для режиссеров
    /// </summary>
    public class Director : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private int moviesCount;
        public int MoviesCount
        {
            get => moviesCount;
            set
            {
                if (moviesCount != value)
                {
                    moviesCount = value;
                    OnPropertyChanged(nameof(MoviesCount));
                }
            }
        }

        private double averageRating;
        public double AverageRating
        {
            get => averageRating;
            set
            {
                if (averageRating != value)
                {
                    averageRating = value;
                    OnPropertyChanged(nameof(AverageRating));
                }
            }
        }

        private int startYear;
        public int StartYear
        {
            get => startYear;
            set
            {
                if (startYear != value)
                {
                    startYear = value;
                    OnPropertyChanged(nameof(StartYear));
                }
            }
        }

        private int endYear;
        public int EndYear
        {
            get => endYear;
            set
            {
                if (endYear != value)
                {
                    endYear = value;
                    OnPropertyChanged(nameof(EndYear));
                }
            }
        }

        /// <summary>
        /// конструктор класса (может понадобиться переделать)
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="MoviesCount">Количество проектов</param>
        /// <param name="AverageRating">Средний рейтинг всех фильмов</param>
        /// <param name="StartYear">Начало активности</param>
        /// <param name="EndYear">Конец активности</param>
        public Director(string name, int moviesCount, double averageRating, int startYear, int endYear)
        {
            Name = name;
            MoviesCount = moviesCount;
            AverageRating = averageRating;
            StartYear = startYear;
            EndYear = endYear;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
