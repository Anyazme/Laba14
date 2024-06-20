using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bib10;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Laba12_4
{
	public class MyListCollection<T> where T : IInit, ICloneable, new()
	{
		public PointCollection<T>? beg = null;
		public PointCollection<T>? end = null;

		int count = 0;
		public int Count => count;

		public PointCollection<T> MakeRandomData()
		{
			T data = new T();
			data.RandomInit();
			return new PointCollection<T>(data);
		}

		public T MakeRandomItem()
		{
			T data = new T();
			data.RandomInit();
			return data;
		}

		public void AddToBegin(T item)
		{
			T newData = (T)item.Clone();//глубокое копирование
			PointCollection<T> newItem = new PointCollection<T>(newData);
			count++;
			if (beg != null)
			{
				beg.Pred = newItem;
				newItem.Next = beg;
				beg = newItem;
			}
			else
			{
				beg = newItem;
				end = beg;
			}
		}

		//вспомогательный метод
		public void AddToEnd(T item)
		{
			T newData = (T)item.Clone();//глубокое копирование 
			PointCollection<T> newItem = new PointCollection<T>(newData); //создаем новый элемент 
			count++;  //увеличиваем счетчик 
			if (end != null)  //проверка
			{
				end.Next = newItem; //следующий элемент связываем 
				newItem.Pred = end; //связываем 
				end = newItem; //ставим end в последний элемент 
			}
			else
			{
				beg = newItem;
				end = beg;
			}
		}

		//конструктор без параметров
		public MyListCollection() { }

		//конструктор с параметрами 
		public MyListCollection(int size)
		{
			if (size <= 0) throw new Exception("size less zero");
			beg = MakeRandomData();
			end = beg;
			for (int i = 1; i < size; i++)
			{
				T newItem = MakeRandomItem();
				AddToEnd(newItem);
			}
			count = size;
		}

		//конструктор для создания списка 
		public MyListCollection(T[] collection)
		{
			if (collection == null) throw new Exception("empty collection null");

			if (collection.Length == 0)
			{
				throw new Exception("empty collection");
			}

			T newData = (T)collection[0].Clone();
			beg = new PointCollection<T>(newData);
			end = beg;
			for (int i = 0; i < collection.Length; i++)
			{
				AddToEnd(collection[i]);
			}
		}

		public void PrintList()
		{
			if (count == 0) Console.WriteLine("The list is empty");
			PointCollection<T>? current = beg;
			for (int i = 0; current != null; i++)
			{
				Console.WriteLine(current.Data);
				current = current.Next;
			}
		}


		public PointCollection<T>? FindItem(T item) //возвращает ссылку на элемент, который ищем
		{
			PointCollection<T>? current = beg;
			while (current != null)
			{
				if (current.Data == null)
				{
					throw new Exception("Data is null");

				}
				if (current.Data.Equals(item))
				{
					return current;
				}
				current = current.Next;
			}
			return null;
		}

		public bool RemoveItem(T item)
		{
			if (beg == null)
			{
				throw new Exception("the empty list");
			}
			PointCollection<T> pos = FindItem(item);
			if (pos == null)
			{
				return false;
			}
			count--;
			//one element
			if (beg == end)
			{
				beg = end = null;
				return true;
			}
			//the first
			if (pos.Pred == null)
			{
				beg = beg?.Next;
				beg.Pred = null;
				return true;
			}
			// the last
			if (pos.Next == null)
			{
				end = end.Pred;
				end.Next = null;
				return true;
			}
			//other situations
			PointCollection<T> next = pos.Next;
			PointCollection<T> pred = pos.Pred;
			pos.Next.Pred = pred;
			pos.Pred.Next = next;
			return true;
		}

		public void AddAtIndex(Aircraft aircraft1, int v)
		{
			throw new NotImplementedException();
		}

		public void RemoveAllIndexedElements()
		{
			throw new NotImplementedException();
		}
	}
}
