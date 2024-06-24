using Bib10;
using Laba12_4;
namespace Laba14
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаем коллекции для хранения данных
			MyListCollection<MyStack<Aircraft>> myListCollection = new MyListCollection<MyStack<Aircraft>>();

			// Заполняем коллекции случайными данными
			Random random = new Random();

			bool exit = false;
			while (!exit)
			{
				Console.WriteLine("Выберите действие:");
				Console.WriteLine("1. Показать аэропорты");
				Console.WriteLine("2. Из всех аэропортов выбрать самолеты");
				Console.WriteLine("3. Найти аэропорт с максимальным количеством самолетов");
				Console.WriteLine("4. Вывести количество воздушных судов каждого типа");
				Console.WriteLine("5. Объединить первый и последний аэропорты");
				Console.WriteLine("6. Соединить города и аэропорты");
				Console.WriteLine("0. Выход");
				Console.Write("Введите номер действия: ");

				if (int.TryParse(Console.ReadLine(), out int choice))
				{
					switch (choice)
					{
						case 1:
							ShowMyListCollection(myListCollection);
							break;

						case 2:
							ShowPlanesEx(myListCollection);
							ShowPlanesLinq(myListCollection);
							break;

						case 3:
							FindMaxAircraftCount(myListCollection);
							FindMaxAircraftCountWithLINQ(myListCollection);
							break;

						case 4:
							GroupByBrandExt(myListCollection);
							break;

						case 5:
							UnionFirstLastExt(myListCollection);
							break;

						case 6:
							Stack<City> stack = new Stack<City>();
							FillMyStackCities(stack);
							ShowCitiesInStack(stack);
							JoinParticipantsAndAircraftsExt(cities,myListCollection);
							break;

						case 0:
							exit = true;
							Console.WriteLine("Выход из программы.");
							break;

						default:
							Console.WriteLine("Неверный выбор. Попробуйте снова.");
							break;
					}
				}
				else
				{
					Console.WriteLine("Неверный ввод. Попробуйте снова.");
				}

				Console.WriteLine();
			}
		}

		static void FillAircraftStacks(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			Random random = new Random();
			int count = random.Next(5, 10);

			for (int i = 0; i < count; i++)
			{
				int countAircraft = random.Next(3, 10);
				MyStack<Aircraft> aircraftStack = new MyStack<Aircraft>();

				for (int j = 0; j < countAircraft; j++)
				{
					int choice = random.Next(1, 4);
					Aircraft aircraft;

					if (choice == 1)
						aircraft = new Helicopter();
					else if (choice == 2)
						aircraft = new Plane();
					else
						aircraft = new Fighter();

					aircraft.RandomInit();
					aircraftStack.Push(aircraft);
				}

				myListCollection.AddToEnd(aircraftStack);
			}
		}

		static void ShowMyListCollection(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			foreach (var stack in myListCollection)
			{
				foreach (var aircraft in stack)
				{
					aircraft.Show();
					Console.WriteLine();
				}
				Console.WriteLine();
			}
		}

		static void ShowPlanesEx(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			Console.WriteLine("LINQ Extension Methods");

			var result = myListCollection.SelectMany(stack => stack)
										 .Where(aircraft => aircraft is Plane);

			foreach (var item in result)
			{
				item.Show();
				Console.WriteLine();
			}
		}


		static void ShowPlanesLinq(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			Console.WriteLine("LINQ");
			var result = from stack in myListCollection
						 from aircraft in stack
						 where aircraft is Plane
						 select aircraft;
			foreach (var item in result)
			{
				item.Show();
				Console.WriteLine();
			}
		}



		static void FindMaxAircraftCount(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			int maxCount = 0;
			int maxStackIndex = 0;

			// Проход по каждому стеку в коллекции, нахождение максимального количества 
			for (int i = 0; i < myListCollection.Count; i++)
			{
				int currentCount = 0;
				foreach (var aircraft in myListCollection[i])
				{
					currentCount++;
				}

				if (currentCount > maxCount)
				{
					maxCount = currentCount;
					maxStackIndex = i;
				}
			}

			// Вывод информацию о максимальном количестве самолетов 
			Console.WriteLine($"Максимальное количество самолетов = {maxCount}, номер стека = {maxStackIndex + 1}");
		}

		static void FindMaxAircraftCountWithLINQ(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			var maxStack = myListCollection.Select((stack, index) => new { Index = index, Count = stack.Count() }).OrderByDescending(item => item.Count).First();

			Console.WriteLine($"Максимальное количество самолетов = {maxStack.Count}, номер стека = {maxStack.Index + 1}");
		}

		static void GroupByBrandExt(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			var result = myListCollection.SelectMany(stack => stack).GroupBy(aircraft => aircraft.Name);
			foreach (var group in result)
			{
				Console.WriteLine($"Модель - {group.Key}, Кол-во - {group.Count()}");
			}
		}

		static void UnionFirstLastExt(MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			var result = myListCollection.First().Union(myListCollection.Last());
			foreach (var item in result)
			{
				item.Show();
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		static void FillMyStackCities(Stack<City> cities)
		{
			Random random = new Random();
			int count = random.Next(5, 10);
			for (int i = 0; i < count; i++)
			{
				City city = new City();
				city.RandomInit();

				cities.Push(city);
			}
		}

		static void ShowCitiesInStack(Stack<City> cities)
		{
			Console.WriteLine("Города в стеке:");

			foreach (var city in cities)
			{
				Console.WriteLine(city.ToString());
			}
		}


		static void JoinParticipantsAndAircraftsExt(Stack<City> cities, MyListCollection<MyStack<Aircraft>> myListCollection)
		{
			var res = from city in cities 
					  from kvp in myListCollection
					  where kvp.Key == ((city.Population % myListCollection.Count) + 1) 
					  select new { City = city, Aircrafts = kvp.Value };

			foreach (var item in res)
			{
				Console.WriteLine($"Город: {item.City}");
				foreach (var aircraft in item.Aircrafts)
				{
					Console.WriteLine($"Самолет: {aircraft}");
				}
			}
			Console.WriteLine();
		}


	}
}