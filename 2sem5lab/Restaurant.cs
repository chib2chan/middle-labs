using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _2sem4lab;

namespace _2sem4lab
{
    /// <summary>
    /// класс "Ресторан" - методов мало не бывает!
    /// </summary>
    public class Restaurant
    {
        public List<Chef> Chefs { get; set; } = [];
        public List<Order> Orders { get; set; } = [];
        public List<Dish> Dishes { get; set; } = [];
        public List<Waiter> Waiters { get; set; } = [];
        public List<Customer> Customers { get; set; } = [];
        
        //для 1-ого случая в свитч кейсе

        /// <summary>
        /// метод, позволяющий зарегистрировать официанта
        /// </summary>
        public void RegisterStaff()
        {
            Chefs.AddRange(
            [
                new() { Id = 1, Name = "Кенджи", TypeOfCuisine = CuisineType.Japanese },
                new() { Id = 2, Name = "Мария", TypeOfCuisine = CuisineType.Italian },
                new() { Id = 3, Name = "Акира", TypeOfCuisine = CuisineType.Japanese },
                new() { Id = 4, Name = "Винченцо", TypeOfCuisine = CuisineType.Italian },
                new() { Id = 5, Name = "Юки", TypeOfCuisine = CuisineType.Japanese },
                new() { Id = 6, Name = "Джованни", TypeOfCuisine = CuisineType.Italian }
            ]);

            Waiters.AddRange(
            [
                new Waiter { Id = 1, Name = "Иннокентий" },
                new Waiter { Id = 2, Name = "Ольга" },
                new Waiter { Id = 3, Name = "Анастасия" },
                new Waiter { Id = 4, Name = "Татьяна" },
                new Waiter { Id = 5, Name = "Максим" },
                new Waiter { Id = 6, Name = "Юлий" }
            ]);

            Dishes.AddRange(
            [
                new() { Id = 1, Name = "Роллы \"Филадельфия\"", Price = 319, Cuisine = CuisineType.Japanese },
                new() { Id = 2, Name = "Роллы \"Калифорния\"", Price = 319, Cuisine = CuisineType.Japanese },
                new() { Id = 3, Name = "Рамён со свининой", Price = 259, Cuisine = CuisineType.Japanese },
                new() { Id = 4, Name = "Тайяки", Price = 229, Cuisine = CuisineType.Japanese },
                new() { Id = 5, Name = "Лазанья", Price = 449, Cuisine = CuisineType.Italian },
                new() { Id = 6, Name = "Пицца \"Маргарита\"", Price = 549, Cuisine = CuisineType.Italian },
                new() { Id = 7, Name = "Паста \"Карбонара\"", Price = 239, Cuisine = CuisineType.Italian },
                new() { Id = 8, Name = "Брускетта", Price = 99, Cuisine = CuisineType.Italian }
            ]);

            Random rand = new();
            //пользователи, ранее успешно зарегистрированные в системе
            Customers.AddRange(
            [
                new() { Id = 1, Name = "Алиса", Balance = rand.Next(300, 10001) },
                new() { Id = 2, Name = "Игнат", Balance = rand.Next(300, 10001) },
                new() { Id = 3, Name = "Дарья", Balance = rand.Next(300, 10001) },
                new() { Id = 4, Name = "Варвара", Balance = rand.Next(300, 10001) }
            ]);
            AddOldOrders(); // Добавление старых заказов для формирования рейтинга блюд
        }

        /// <summary>
        /// Метод для добавления старых заказов
        /// (Считайте это цифровизацией бумажных архивов)
        /// </summary>
        private void AddOldOrders()
        {
            var oldOrders = new List<Order>
            {
                new() {
                    Id = 1,
                    TableNumber = 5,
                    CustomerId = 1,
                    WaiterId = 1,
                    Dishes = [Dishes[0], Dishes[1]]
                },
                new() {
                    Id = 2,
                    TableNumber = 5,
                    CustomerId = 3,
                    WaiterId = 1,
                    Dishes = [Dishes[6], Dishes[6], Dishes[6], Dishes[7]]
                },
                new() {
                    Id = 3,
                    TableNumber = 5,
                    CustomerId = 1,
                    WaiterId = 1,
                    Dishes = [Dishes[6], Dishes[6], Dishes[6], Dishes[7]]
                },
                new() {
                    Id = 4,
                    TableNumber = 5,
                    CustomerId = 2,
                    WaiterId = 1,
                    Dishes = [Dishes[6], Dishes[6], Dishes[6], Dishes[7]]
                },
                new() {
                    Id = 5,
                    TableNumber = 5,
                    CustomerId = 1,
                    WaiterId = 1,
                    Dishes = [Dishes[6], Dishes[7], Dishes[7], Dishes[7]]
                },
                new() {
                    Id = 6,
                    TableNumber = 5,
                    CustomerId = 1,
                    WaiterId = 1,
                    Dishes = [Dishes[4], Dishes[5], Dishes[6], Dishes[7]]
                },
                new() {
                    Id = 7,
                    TableNumber = 5,
                    CustomerId = 1,
                    WaiterId = 1,
                    Dishes = [Dishes[7], Dishes[6], Dishes[4], Dishes[7]]
                },
                new() {
                    Id = 8,
                    TableNumber = 5,
                    CustomerId = 4,
                    WaiterId = 1,
                    Dishes = [Dishes[6], Dishes[7], Dishes[6], Dishes[7]]
                },
                new() {
                    Id = 9,
                    TableNumber = 5,
                    CustomerId = 1,
                    WaiterId = 1,
                    Dishes = [Dishes[6], Dishes[7], Dishes[6], Dishes[7]]
                },
                new() {
                    Id = 10,
                    TableNumber = 5,
                    CustomerId = 4,
                    WaiterId = 1,
                    Dishes = [Dishes[6], Dishes[7], Dishes[6], Dishes[7]]
                },
                new() {
                    Id = 11,
                    TableNumber = 3,
                    CustomerId = 2,
                    WaiterId = 2,
                    Dishes = [Dishes[3], Dishes[3], Dishes[3]]
                },
                new() {
                    Id = 12,
                    TableNumber = 7,
                    CustomerId = 3,
                    WaiterId = 3,
                    Dishes = [Dishes[5], Dishes[3]]
                }
            };

            Orders.AddRange(oldOrders);
        }

        /// <summary>
        /// Метод, позволяющий регистрировать новых посетителей
        /// </summary>
        public void MakeOrder()
        {
            ChangeColor("Введите имя Вашего посетителя: ", ConsoleColor.Yellow);
            string customerName = InputSymbols(Console.ReadLine());
            Customer customer = FindCustomerByName(customerName);

            if (customer == null)
            {
                customer = RegisterNewCustomer(customerName);
                ChangeColor($"\n{customerName}, теперь Вы зарегистрированы в системе (как посетитель)" +
                    $"\nВаш текущий баланс составляет ${customer.Balance}", ConsoleColor.DarkYellow);
            }
            else ChangeColor($"Рады видеть Вас снова, {customerName}!" +
                    $"\nВаш текущий баланс составляет ${customer.Balance}", ConsoleColor.DarkYellow);
            
            ChangeColor("Официант, запишите себе номер столика: ", ConsoleColor.Yellow);
            int tableNumber = ConverterInt(Console.ReadLine()); //требуется только для выноса заказа, ни на что не влияет
            
            ChangeColor("Официант, введите свой ID: ", ConsoleColor.Yellow);
            int waiterId;

            //дураков C# не любит
            while (true)
            {
                waiterId = ConverterInt(Console.ReadLine());
                if (waiterId >= 1 && waiterId <= 6) break;
                ChangeColor("Некорректный ID. Введите целое число от 1 до 6: ", ConsoleColor.Red);
            }

            Order order = new()
            {
                Id = Orders.Count + 1,
                TableNumber = tableNumber,
                CustomerId = customer.Id,
                WaiterId = waiterId,
                Dishes = []
            };

            ShowAvailableDishes();
            ChangeColor("Перечислите список блюд, заказанных посетителем" +
                        "(используйте числа от 1 до 8, разделяйте позиции через пробел): ", ConsoleColor.Yellow);

            List<int> dishIds = [];
            bool isValidInput = false;

            //защита от дурашек
            while (!isValidInput)
            {
                string[] parts = InputSymbols(Console.ReadLine()).Split(' ');
                bool everythingIsOkay = true;

                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int id))
                    {
                        if (id >= 1 && id <= 8)
                        {
                            dishIds.Add(id - 1); //потому что индекс
                        }
                        else
                        {
                            ChangeColor($"Некорректный ввод: {part}. Используйте числа от 1 до 8.", ConsoleColor.Red);
                            everythingIsOkay = false;
                            break;
                        }
                    }
                }

                if (everythingIsOkay && dishIds.Count > 0)
                {
                    isValidInput = true;
                }
                else
                {
                    dishIds.Clear(); //и вперед по новой
                    ChangeColor("Пожалуйста, повторите ввод.", ConsoleColor.Red);
                }
            }

            foreach (var dishId in dishIds)
            {
                Dish dish = Dishes.FirstOrDefault(dish => dish.Id == dishId); //linq

                if (dish != null && customer.Balance >= dish.Price)
                {
                    order.Dishes.Add(dish);
                    customer.Balance -= dish.Price;
                }
            }

            TakeOrder(order);
            ChangeColor("Ваш заказ принят. Пожалуйста, подождите...", ConsoleColor.Green);
            ProcessOrderAsync(order, this);
        }

        /// <summary>
        /// метод, проверяющий наличие пользователя в системе
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <returns>посетитель в системе</returns>
        public Customer FindCustomerByName(string name)
        {
            return Customers.FirstOrDefault(customer => customer.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// метод, регистрирующий с нуля нового посетителя (после его представления)
        /// </summary>
        /// <param name="name">имя посетителя</param>
        /// <returns>зарегистрированный пользователь</returns>
        public Customer RegisterNewCustomer(string name)
        {
            Random rand = new();
            double balance = rand.Next(500, 5001);

            Customer newCustomer = new()
            {
                Id = Customers.Count + 1,
                Name = name,
                Balance = balance
            };

            Customers.Add(newCustomer);
            return newCustomer;
        }

        /// <summary>
        /// метод, просто выводящий меню на экран
        /// </summary>
        public void ShowAvailableDishes()
        {
            ChangeColor("Меню:", ConsoleColor.DarkYellow);
            foreach (var dish in Dishes)
            {
                Console.WriteLine($"{dish.Id}. {dish.Name} ({dish.Cuisine}) - ${dish.Price}");
            }
        }

        /// <summary>
        /// метод, позволяющий отслеживать время приготовления заказа
        /// </summary>
        /// <param name="order">содержимое заказа</param>
        /// <param name="restaurant">ресторан, в котором происходит приготовление заказа</param>
        public static async void ProcessOrderAsync(Order order, Restaurant restaurant)
        {
            int totalTimeInSeconds = 30 * 60;
            Stopwatch stopwatch = Stopwatch.StartNew();

            ChangeColor($"Готовим заказ #{order.Id}... Оставшееся время: {totalTimeInSeconds / 60}мин {totalTimeInSeconds % 60}сек", ConsoleColor.Cyan);

            ///если раскомментировать строку ниже,
            ///то можно получать уведомления на главном экране о том, как долго осталось ждать заказ
            ///(только ради этого использую асинхрон)

            while (stopwatch.Elapsed.TotalSeconds < totalTimeInSeconds)
            {
                await Task.Delay(1200000); //каждые две минуты "просыпается"
                int remainingTimeInSeconds = totalTimeInSeconds - (int)stopwatch.Elapsed.TotalSeconds;
                ChangeColor($"Order #{order.Id} processing... Remaining time: {remainingTimeInSeconds / 60}m {remainingTimeInSeconds % 60}s", ConsoleColor.Cyan);
            }

            stopwatch.Stop();
            Console.WriteLine($"Заказ #{order.Id} готов. Пожалуйста, отнесите его на столик #{order.TableNumber}");

            foreach (var dish in order.Dishes) // Уменьшение заказов у поваров - для правдоподобия
            {
                var chef = restaurant.Chefs.FirstOrDefault(chef => chef.TypeOfCuisine == dish.Cuisine && chef.OrdersHandled > 0);
                if (chef != null) chef.OrdersHandled--;
            }
        }

        /// <summary>
        /// метод, позволяющий составить отчет о том, какой повар делает какой заказ
        /// </summary>
        /// <param name="order">все данные заказа</param>
        public void TakeOrder(Order order)
        {
            ///в рамках данного метода необходимо разделить все блюда на соответствующие кухни
            ///и назначить на каждое блюдо своего шеф-повара
            ///предусмотрите вывод информации о необходимости ожидать заказ более часа
            ///(сделать это можно разными способами),
            ///если нет свободных шефов (!)

            foreach (var dish in order.Dishes)
            {
                var availableChefs = Chefs.Where(chef => chef.TypeOfCuisine == dish.Cuisine && chef.OrdersHandled < 3).ToList();

                if (availableChefs.Count != 0)
                {
                    var chef = availableChefs.First();
                    chef.OrdersHandled++;
                    ChangeColor($"Dish '{dish.Name}' assigned to chef {chef.Name} (because of {dish.Cuisine} cuisine)", ConsoleColor.DarkCyan);
                }
                else
                {
                    ChangeColor($"No available chefs for dish '{dish.Name}'. The order may take longer.", ConsoleColor.DarkCyan);
                }
            }
            Orders.Add(order);
            Waiters.First(waiter => waiter.Id == order.WaiterId).OrdersHandled++;
        }

        //фичи для остальных случаев свитч кейса

        /// <summary>
        /// Метод, возвращающий отчет о популярных блюдах + LINQ
        /// </summary>
        /// <returns>Строка с популярными блюдами</returns>
        public string ShowPopularDishes()
        {
            /// важно: надо подсчитать, сколько рах какое блюдо было заказано,
            /// и вывести все позиции в порядке убывания популярности.
            /// 
            /// Для этого можно использовать вариант следующего LINQ запроса:
            /// используйте оператор SelectMany, чтобы получить плоский список
            /// всех блюд из заказов
            /// 
            /// После того, как Вы получите все блюда в одном списке, 
            /// сгруппируйте их по имени блюда.
            /// 
            /// Далее, вам необходимо пройтись по каждой группе и создать новый
            /// анонимный объект для каждой группы, который будет иметь следующую структуру
            /// 
            /// g.Key - это имя блюда (так как мы группировали по имени)
            /// g.Count() - это количество элементов в группе, то есть количество раз, когда данное блюдо было заказано
            ///
            /// В результате вы должны получить коллекцию анонимных объектов,
            /// каждый из которых содержит имя блюда и количество раз, когда оно было заказано
            /// Последним шагом отсортируйте полученные объекты по количеству заказов в порядке убывания,
            /// используя оператор OrderByDescending

            var popularDishes = Orders
                .SelectMany(order => order.Dishes)
                .GroupBy(dish => dish.Name)       
                .Select(g => new
                {
                    DishName = g.Key,
                    Count = g.Count()
                });
                //можно вернуть ордер бу десендер

            if (!popularDishes.Any()) return "Заказы ещё не были составлены.";

            string result = "Список популярных блюд:\n";

            foreach (var dish in popularDishes)
            {
                result += $"- {dish.DishName} - заказано целых {dish.Count} раз!\n";
            }

            return result;
        }

        /// <summary>
        /// Метод для вывода информации о приготовлении заказов
        /// </summary>
        /// <returns>особую строку с данными о заказах</returns>
        public string OrdersInfo()
        {
            string RemainingOrders = "";
            //заказы есть всегда, поскольку существуют "старые заказы"
            foreach (var order in Orders)
            {
                RemainingOrders += $"\nOrder #{order.Id}:";

                foreach (var dish in order.Dishes)
                {
                    var chef = Chefs.FirstOrDefault(chef => (chef.TypeOfCuisine == dish.Cuisine) && (chef.OrdersHandled < 3));
                        
                    if (chef != null) RemainingOrders += $"\n- {dish.Name} from {dish.Cuisine} is being prepared by {chef.Name}";
                    else RemainingOrders += $"\n- {dish.Name} is waiting for a chef. Please, wait";
                }
            }

            return RemainingOrders;
        }

        /// <summary>
        /// метод, возвращающий отчет о работе официантов + LINQ
        /// </summary>
        /// <returns>особая строка с данными о работе официантов</returns>
        public string ShowHardworkingWaiters()
        {
            ///В данном случае, Вам необходимо сформировать коллекцию,
            ///содержащую официантов, отсортированных по количеству обработанных заказов
            ///Для этого вы можете использовать метод OrdersHandled каждого объекта

            string waiters = "";
            List<Waiter> hardworkingWaiters = [.. Waiters.OrderByDescending(waiter => waiter.OrdersHandled)]; //linq

            waiters += "Waiter's working report:";
            foreach (var waiter in hardworkingWaiters)
            {
                string rating = waiter.OrdersHandled > 5 ? "Highly rated!" : "Goodly rated!";

                waiters +=  $"\n{waiter.Name}: {waiter.OrdersHandled} orders handled\n\t{waiter.Name} rating: {rating}";
            }

            return waiters;
        }

        /// <summary>
        /// метод, позволяющий получить данные о сделанных заказах + LINQ
        /// </summary>
        /// <returns>особую строку с данными о заказах клиентов</returns>
        public string ShowReportAboutCustomers()
        {
            ///цель этого отчета - получить сводную информацию о заказах клиентов
            ///в разрезе общей суммы всех заказов и количества этих заказов,
            ///что может быть полезно для анализа продаж или расчета бонусов
            ///
            /// Вы можете использовать LINQ запрос следующей структуры
            /// 
            /// Вам необходимо соединить две коллекции: Orders и Customers
            /// Используйте для этого оператор Join
            /// Вы должны соединить заказы с клиентами по полям IdOfCustomer из заказа и Id из клиента
            /// Это позволит получить информацию о клиенте для каждого заказа
            /// 
            /// После соединения мы группируем заказы по имени клиента (client.Name)
            /// Используйте для этого оператор group by
            /// Результат группировки сохраняется в переменной g
            /// 
            /// В каждой группе g будут находиться все заказы, сделанные конкретным клиентом
            /// 
            /// Далее сформируйте новый анонимный объект для каждой группы,
            /// который будет содержать необходимые данные:
            /// .
            /// - ClientName: имя клиента
            /// - TotalDishes: общее количество денег, потраченных клиентом на заказы
            /// - TotalOrderCount: общее количество заказов, сделанных клиентом
            
            var customerReports = Orders
                .Join(Customers, //linq
                      order => order.CustomerId,
                      customer => customer.Id,
                      (order, customer) => new { CustomerName = customer.Name, Order = order })
                .GroupBy(x => x.CustomerName) //linq
                .Select(g => new //linq
                    {
                        ClientName = g.Key,
                        TotalSpent = g.Sum(x => x.Order.Dishes.Sum(dish => dish.Price)),
                        TotalOrders = g.Count()
                    });

            return string.Join("\n", customerReports.Select(customer => //LINQ
                $"{customer.ClientName}: Total spent ${customer.TotalSpent}, Orders: {customer.TotalOrders}"));
        }

        //дополнительные фичи
        /// <summary>
        /// Метод для проверки строки на пустоту
        /// </summary>
        /// <param name="s">Введенная пользователем строка</param>
        public static string InputSymbols(string s)
        {
            if (!string.IsNullOrEmpty(s)) return s;
            else
            {
                Console.WriteLine("Вы ничего не ввели. Введите:");
                s = Console.ReadLine();
            }
            return s;
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
                        Console.WriteLine("You entered invalid numbers.");
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