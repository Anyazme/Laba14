using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bib10;

namespace Laba14
{
	public class MyStack<T> : IEnumerable<T> where T : IInit, ICloneable, IComparable, new()
	{
		private LinkedList<T> list = new LinkedList<T>();

		public int Count => list.Count;

		public void Add(T item)
		{
			list.AddLast(item);
		}

		public T Remove()
		{
			if (list.Count == 0)
				throw new InvalidOperationException("Стек пустой");

			T value = list.Last.Value;
			list.RemoveLast();
			return value;
		}

		public T Return()
		{
			if (list.Count == 0)
				throw new InvalidOperationException("Стек пустой");

			return list.Last.Value;
		}

		public bool Contains(T item)
		{
			return list.Contains(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)list).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
