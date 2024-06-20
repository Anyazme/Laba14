using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laba14
{
	public class Airport
	{
		static string[] NameAirports = { "Хабаровск", "Москва", "Санкт - Петербург", "Пермь", "Нижний Новгород" };
		Random rnd = new Random();

		public string NameAirport { get; set; }
		public int number;

		public int Number
		{
			get { return number; }
			set
			{
				if (value < 0)
				{
					number = 0;
				}
				else
				{
					number = value;
				}
			}
		}

		public Airport() { }

		public Airport(string nameAirport)
		{
			NameAirport = nameAirport;
			Number = number;
		}

		public virtual void Show()
		{
			Console.WriteLine($"Название аэропорта: {NameAirport}, вместимость: {Number}");
		}

		public virtual void Init()
		{

			Console.WriteLine("Введите, пожалуйста, название аэропорта");
			NameAirport = Console.ReadLine();
			Console.WriteLine("Введите, пожалуйста, вместимость аэропорта");
			Number = int.Parse(Console.ReadLine());

		}
		public virtual void RandomInit()
		{
			NameAirport = NameAirports[rnd.Next(NameAirports.Length)];
			Number = rnd.Next(1, 10000);  // Генерация случайной вместимости
		}

		public override string ToString()
		{
			return $"Название аэропорта: {NameAirport}, вместимость: {Number}";
		}

		public override int GetHashCode()
		{
			return NameAirport.GetHashCode() ^ Number.GetHashCode();
		}

		public int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType()) return false;
			Airport other = obj as Airport;
			return NameAirport == other.NameAirport && Number == other.Number;
		}

		public object Clone()
		{
			throw new NotImplementedException();
		}
	}
}