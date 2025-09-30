using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MovieRating;

namespace MovieRating.Model
{
    /// <summary>
    /// Класс для фильмов
    /// </summary>
    public class Movie : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string genre;
        public string Genre
        {
            get => genre;
            set
            {
                if (genre != value)
                {
                    genre = value;
                    OnPropertyChanged(nameof(Genre));
                }
            }
        }

        private int year;
        public int Year
        {
            get => year;
            set
            {
                if (year != value)
                {
                    year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        private string directorName;
        public string DirectorName
        {
            get => directorName;
            set
            {
                if (directorName != value)
                {
                    directorName = value;
                    OnPropertyChanged(nameof(DirectorName));
                }
            }
        }

        private double rating;
        public double Rating
        {
            get => rating;
            set
            {
                if (rating != value)
                {
                    rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }

        public Movie(string title, string genre, int year, string directorName, double rating)
        {
            Title = title;
            Genre = genre;
            Year = year;
            DirectorName = directorName;
            Rating = rating;
        }

        /// <summary>
        /// метод для проверки свойства на изменение
        /// </summary>
        /// <param name="propertyName">свойство, которое проверяем на изменения</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}