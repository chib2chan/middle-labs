using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MovieRating.Model;
using MovieRating;

namespace MovieRating.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// конструктор класса
        /// </summary>
        public MainViewModel()
        {
            AllMovies =
            [
                new("Гарри Поттер и философский камень", "Приключения", 2001, "Крис Коламбус", 8.3),
                new("Адвокат Дьявола", "Драма", 1997, "Тейлор Хэкфорд", 8.2),
                new("7 лаба", "Хоррор", 2025, "Алексей Зайцев", 1000-7),
                new("Гарри Поттер и философский камень", "Приключения", 2001, "Крис Коламбус", 8.3),
                new("Адвокат Дьявола", "Драма", 1997, "Тейлор Хэкфорд", 8.2),
                new("Терминал", "Драма", 2004, "Стивен Спилберг", 8.1),
                new("Титаник", "Драма", 1997, "Джеймс Камерон", 7.5),
                new("Индиана Джонс: В поисках утраченного ковчега", "Боевик", 1981, "Стивен Спилберг", 8),
                new("Дьявол носит Prada", "Драма", 2006, "Дэвид Фрэнкел", 7.7),
                new("Пираты Карибского моря: На краю света", "Приключения", 2007, "Гор Вербински", 7.9),
                new("Шерлок Холмс", "Детектив", 2009, "Джеймс Кэмерон", 7.6),
                new("Мстители", "Боевик", 2012, "Люк Эванс", 8.0),
                new("Принцесса Уэльская", "Комедия", 1999, "Роберт Леттерер", 7.8),
                new("Назад в будущее", "Комедия", 1985, "Роберт Земекис", 8.5),
                new("Трансформеры", "Боевик", 2007, "Майкл Бэй", 7.0),
                new("Матрица", "Боевик", 1999, "Ланы Вачовски", 8.7),
                new("Детективы", "Детектив", 2018, "Алексей Балабанов", 7.2),
                new("Большая рыба", "Комедия", 2019, "Игорь Копылов", 6.8),
                new("Джуманджи: Наследие", "Приключения", 2017, "Джон Хенкс", 7.4),
                new("Брат", "Боевик", 1997, "Фёдор Бондарчук", 8.0),
                new("Левиафан", "Драма", 2014, "Андрей Звягинцев", 8.5),
                new("Дуэль", "Комедия", 1999, "Юрий Малышев", 7.8),
                new("Судьба человека", "Драма", 1947, "Георгий Даниэль", 8.2),
                new("Маленькая Мисс Сейф", "Боевик", 2002, "Стивен Спилберг", 7.8),
                new("Индиана Джонс: Распад империи", "Боевик", 1989, "Стивен Спилберг", 7.9),
                new("Таинственный лес", "Приключения", 2001, "Стивен Спилберг", 7.6),
                new("Аватар", "Фантастика", 2009, "Джеймс Камерон", 8.4),
                new("Поток", "Драма", 2012, "Джеймс Камерон", 7.3),
                new("Матрица 2", "Боевик", 2003, "Ланы Вачовски", 7.8),
                new("Матрица 3", "Боевик", 2003, "Ланы Вачовски", 7.5),
                new("Судьба капитана", "Боевик", 2002, "Фёдор Бондарчук", 7.7),
                new("Дом на краю света", "Боевик", 2012, "Фёдор Бондарчук", 7.4),
                new("Курьер", "Драма", 2019, "Андрей Звягинцев", 8.1),
                new("Ночь", "Драма", 2016, "Андрей Звягинцев", 7.9),
                new("Солдаты", "Комедия", 1999, "Юрий Малышев", 7.6),
                new("Малый бизнес", "Комедия", 2000, "Юрий Малышев", 7.5),
                new("Герой нашего времени", "Драма", 1977, "Георгий Даниэль", 8.0),
                new("Они сражались за Родину", "Драма", 1973, "Георгий Даниэль", 8.3)
            ];

            Directors = [];
            UpdateDirectors();
            FilteredMovies = [.. AllMovies];

            AddMovieCommand = new RelayCommand(AddMovie);
            RemoveMovieCommand = new RelayCommand(RemoveMovie);
            ShowMessageCommand = new RelayCommand(ShowMessage);
            SortedByDescendingCommand = new RelayCommand(SortByRatingDescending);
            SortedByAscendingCommand = new RelayCommand(SortByRatingAscending);
            SortByPeriodCommand = new RelayCommand(SortByPeriod);
            SortByGenreCommand = new RelayCommand(SortByGenre);
            ResetCommand = new RelayCommand(ResetFilter);

            ///проверка на изменение свойств:
            ///если в разделе фильтрации указаны хоть какие-то условия,
            ///то они могут выполниться без нажатия отдельных кнопок
            ///(например, выбор жанра или выбор дат для сортировки;
            ///очень удобно, когда необходимо применить двойную сортировку)
            ///однако приличия ради я добавила отдельные команды :3
            PropertyChanged += (s, e) =>
            {
                var trackedProps = new[] { nameof(SearchGenre), nameof(YearFrom), nameof(YearTo) };
                if (trackedProps.Contains(e.PropertyName)) ApplySearch();
            };
        }

        /// команды: нужны для того, чтобы связать действия в View
        /// (например, нажатие кнопки) с методами в ViewModel

        public ICommand AddMovieCommand { get; }
        public ICommand RemoveMovieCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand ShowMessageCommand { get; }
        public ICommand SortedByDescendingCommand { get; }
        public ICommand SortedByAscendingCommand { get; }
        public ICommand SortByPeriodCommand { get; }
        public ICommand SortByGenreCommand { get; }

        /// <summary>
        /// поля и коллекции
        /// приватные переменные для того, чтобы настроить геттеры и сеттеры
        /// (поля в принципе следует делать приватными)
        /// в сеттерах прописана настройка для проверки изменения данных свойств
        /// </summary>

        private ObservableCollection<Movie> _allMovies;
        public ObservableCollection<Movie> AllMovies
        {
            get => _allMovies;
            set
            {
                _allMovies = value;
                OnPropertyChanged(nameof(AllMovies));
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        private ObservableCollection<Director> directors;
        public ObservableCollection<Director> Directors
        {
            get => directors;
            set
            {
                directors = value;
                OnPropertyChanged(nameof(Directors));
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        private ObservableCollection<Movie> filteredMovies;
        public ObservableCollection<Movie> FilteredMovies
        {
            get => filteredMovies;
            set
            {
                filteredMovies = value;
                OnPropertyChanged(nameof(FilteredMovies));
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
        public static ObservableCollection<string> Genres
        {
            get { return ["Детектив", "Драма", "Хоррор", "Боевик", "Комедия", "Приключения", "Другое"]; }
        }

        private Movie _selectedMovie;
        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(_selectedMovie));
            }
        }

        private string _newTitle;
        public string NewTitle
        {
            get => _newTitle;
            set
            {
                if (_newTitle != value)
                {
                    _newTitle = value;
                    OnPropertyChanged(nameof(NewTitle));
                }
            }
        }

        private string? _newGenre;
        public string NewGenre
        {
            get => _newGenre;
            set
            {
                if (_newGenre != value)
                {
                    _newGenre = value;
                    OnPropertyChanged(nameof(NewGenre));
                }
            }
        }

        private int? _newYear;
        public int? NewYear
        {
            get => _newYear;
            set
            {
                if (_newYear != value)
                {
                    _newYear = value;
                    OnPropertyChanged(nameof(NewYear));
                }
            }
        }

        private string? newDirector;
        public string NewDirector
        {
            get => newDirector;
            set
            {
                if (newDirector != value)
                {
                    newDirector = value;
                    OnPropertyChanged(nameof(NewDirector));
                }
            }
        }

        private double? _newRating;
        public double? NewRating
        {
            get => _newRating;
            set
            {
                if (_newRating != value)
                {
                    _newRating = value;
                    OnPropertyChanged(nameof(NewRating));
                }
            }
        }

        private string? _searchGenre;
        public string SearchGenre
        {
            get => _searchGenre;
            set
            {
                if (_searchGenre != value)
                {
                    _searchGenre = value;
                    OnPropertyChanged(nameof(SearchGenre));
                }
            }
        }

        private int? _yearFrom;
        public int? YearFrom
        {
            get => _yearFrom;
            set
            {
                if (_yearFrom != value)
                {
                    _yearFrom = value;
                    OnPropertyChanged(nameof(YearFrom));
                }
            }
        }

        private int? _yearTo;
        public int? YearTo
        {
            get => _yearTo;
            set
            {
                if (_yearTo != value)
                {
                    _yearTo = value;
                    OnPropertyChanged(nameof(YearTo));
                }
            }
        }

        /// <summary>
        /// рабочий метод для добавления фильма в фильмотеку
        /// </summary>
        private void AddMovie()
        {
            ///добавляет фильм только в том случае, если все данные выбраны.
            ///иначе есть риск, что появятся "белые пятна"
            if (!string.IsNullOrWhiteSpace(NewTitle) &&
                !string.IsNullOrWhiteSpace(NewGenre) &&
                NewYear.HasValue &&
                NewDirector != null &&
                NewRating.HasValue)
            {
                var newMovie = new Movie
                (
                    NewTitle,
                    NewGenre,
                    NewYear.Value,
                    NewDirector,
                    NewRating.Value
                );

                AllMovies.Add(newMovie);
                ///чтобы данные о всех фильмах синхронизировалось с таблицей директоров
                UpdateDirectors();
                ///чтобы не пришлось вводить все по новой каждый раз
                ClearInputFields(); 
            }
        }

        /// <summary>
        /// рабочий метод для удаления фильма
        /// </summary>
        private void RemoveMovie()
        {
            if (SelectedMovie != null)
            {
                AllMovies.Remove(SelectedMovie);
                UpdateDirectors();
                ApplySearch();
            }
        }

        /// <summary>
        /// рабочий метод, восстанавливающий исходное положение фильмов в фильмотеке
        /// </summary>
        private void ResetFilter()
        {
            SearchGenre = null;
            YearFrom = null;
            YearTo = null;
            ApplySearch();
        }

        /// <summary>
        /// рабочий метод для обновления списка режиссеров
        /// </summary>
        private void UpdateDirectors()
        {
            ///использование линку для получения данных о режиссерах:
            ///1. Имя режиссера
            ///2. Сколько фильмов соответствует имени режиссера
            ///3. Среднее арифметическое рейтингов всех фильмов режиссера
            ///4. Минимальный год выпущенного фильма => начало активности
            ///5. Соответственно, конец активности
            var directors = AllMovies
                .GroupBy(m => m.DirectorName)
                .Select(g => new Director(
                    g.Key,
                    g.Count(),
                    g.Average(m => m.Rating),
                    g.Min(m => m.Year),
                    g.Max(m => m.Year)
                ))
                .ToList();

            ///если нет необходимости фильтровать режиссеров,
            ///просто закомментируйте
            if (FilteredMovies != null)
            {
                directors = FilteredMovies
                .GroupBy(m => m.DirectorName)
                .Select(g => new Director(
                    g.Key,
                    g.Count(),
                    g.Average(m => m.Rating),
                    g.Min(m => m.Year),
                    g.Max(m => m.Year)
                ))
                .ToList();
            }

            ///очистка старой таблицы
            Directors.Clear();

            ///построчное добавление данных о режиссерах
            ///(чтобы образовалась удобная таблица)
            foreach (var director in directors)
            {
                Directors.Add(director);
            }
        }

        /// <summary>
        /// рабочий метод для обновления фильтров
        /// почему она все-таки есть: благодаря ей список учитывает все фильтры
        /// то есть можно одновременно сортировать и по жанру, и по дате, например
        /// </summary>
        private void ApplySearch()
        {
            var query = AllMovies.AsQueryable();

            /// перебор по жанру
            if (!string.IsNullOrEmpty(SearchGenre))
                query = query.Where(m => m.Genre == SearchGenre);

            /// перебор по начальному году
            if (YearFrom.HasValue)
                query = query.Where(m => m.Year >= YearFrom.Value);

            /// перебор по конечному году
            if (YearTo.HasValue)
                query = query.Where(m => m.Year <= YearTo.Value);

            ///фиксируем данные о том, какие фильмы мы можем оставить
            FilteredMovies = [.. query];
            OnPropertyChanged(nameof(FilteredMovies));
            UpdateDirectors();
        }

        /// <summary>
        /// Рабочий метод сортировки по временному периоду (по году)
        /// </summary>
        private void SortByPeriod()
        {
            var sortedMovies = FilteredMovies.OrderBy(m => m.Year).ToList();
            ///сортировка может выполниться даже в том случае, если указана одна из временных границ.
            ///если пользователь ввел обе - ну, круто. меньше проблем и оговорок.
            if (YearFrom.HasValue) sortedMovies = [.. sortedMovies.Where(m => m.Year >= YearFrom.Value)];
            if (YearTo.HasValue) sortedMovies = [.. sortedMovies .Where(m => m.Year <= YearTo.Value)];
            
            FilteredMovies = [.. sortedMovies];
            OnPropertyChanged(nameof(FilteredMovies));
            UpdateDirectors();
        }

        /// <summary>
        /// рабочий метод для сортировки по жанру (сортировка по алфавиту)
        /// </summary>
        private void SortByGenre()
        {
            FilteredMovies = [.. FilteredMovies.OrderBy(m => m.Genre)];
            OnPropertyChanged(nameof(FilteredMovies));
            UpdateDirectors();
        }

        /// <summary>
        /// рабочий метод для сортировки по возрастанию рейтинга
        /// </summary>
        private void SortByRatingAscending()
        {
            FilteredMovies = [.. FilteredMovies.OrderBy(m => m.Rating)];
            OnPropertyChanged(nameof(FilteredMovies));
            UpdateDirectors();
        }

        /// <summary>
        /// рабочий метод для сортировки по убыванию рейтинга
        /// </summary>
        private void SortByRatingDescending()
        {
            FilteredMovies = [.. FilteredMovies.OrderByDescending(m => m.Rating)];
            OnPropertyChanged(nameof(FilteredMovies));
            UpdateDirectors();
        }

        /// <summary>
        /// рабочий метод для очистки ВСЕХ полей
        /// используется после ввода данных о фильме и после вызова "сброс фильтров"
        /// </summary>
        private void ClearInputFields()
        {
            NewTitle = string.Empty;
            NewYear = null;
            NewDirector = string.Empty;
            NewRating = null;
            YearFrom = null;
            YearTo = null;
            SearchGenre = string.Empty;
        }

        /// <summary>
        /// рабочий метод для непонятных примочек - потом сделала его как инструкцию
        /// (использовала для того, чтобы связать команды с кнопками в WPF
        /// на этапе, когда ещё не разработала команды)
        /// </summary>
        private void ShowMessage()
        {
            ///просто вывод инструкции. остался у тех кнопок, которые мне "не понравились"
            MessageBox.Show("\tИнструкция:" +
                "\n\n1. Ввести данные в раздел формы 'Добавить/удалить фильм', если Вы желаете его добавить" +
                "\n\n2. Если Вы желаете удалить фильм, следует нажать на строку таблицы с данным фильмом и затем нажать на 'удалить'" +
                "\n\n3. Если Вы хотите применить сортировку, необходимо сначала заполнить все интересующие Вас поля (жанр, годы и т.п.)" +
                "\nЕсли Вы желаете вернуть коллекцию фильмов к тому виду, в котором она была до сортировки - нажмите 'Сбросить фильтры'" +
                "\nУчтите, что удаленные Вами фильмы и добавленные вносятся в неотсортированную фильмотеку!" +
                "И примите к сведению, что запись данных о фильме возможна лишь в ситуации," +
                "когда вы целиком вносите достоверные сведения о фильме");
        }

        /// <summary>
        /// рабочий метод для изменения данных внутри свойства
        /// (например, текста внутри текст-бокса)
        /// </summary>
        /// <param name="propertyName">название свойства</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}