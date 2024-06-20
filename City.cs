using Bib10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Laba14
{
	public class City: IInit, ICloneable, IComparable
	{
		static string[] Names = { "Хабаровск", "Москва", "Санкт - Петербург", "Пермь", "Нижний Новгород" };
		Random rnd = new Random();

		public string Name { get; set; } 

		public City() { }

		public City(string name)
		{
			Name = name;
		}

		public virtual void Show()
		{
			Console.WriteLine($"Название города: {Name}");
		}

		public virtual void Init()
		{

			Console.WriteLine("Введите, пожалуйста, название города");
			Name = Console.ReadLine();

		}
		public virtual void RandomInit()
		{
			Name = Names[rnd.Next(Names.Length)];
		}

		public override string ToString()
		{
			return Name;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as City);
		}

		public object Clone()
		{
			throw new NotImplementedException();
		}
	}
}
