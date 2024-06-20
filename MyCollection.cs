using Bib10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12_4
{
	public class MyCollection<T> : MyListCollection<T>, IEnumerable<T> where T : IInit, ICloneable, new()
	{
		public MyCollection() : base() { }
		public MyCollection(int size) : base() { }
		//public MyCollection(T[] collection) : base(collection) { }

		public IEnumerator<T> GetEnumerator()
		{
			return new MyEnumerator<T>(this);
		}

		 IEnumerator IEnumerable.GetEnumerator()
		 {
			return GetEnumerator();
		 }

	}

	public class MyEnumerator<T> : IEnumerator<T> where T: IInit, ICloneable, new()
	{
	    PointCollection<T>? beg;
		PointCollection<T>? current;
		public MyEnumerator(MyCollection<T> collection)
		{
			beg = collection.beg;
			current = beg;
		}
		public T Current => current.Data;

		object IEnumerator.Current => throw new NotImplementedException();

		public void Dispose()
		{
			
		}

		public bool MoveNext()
		{
			if(current == null || current.Next == null)
			{
				Reset();
				return false;
			}
			else
			{
				current = current.Next;
				return true;
			}
		}

		public void Reset()
		{
			current = beg;
		}
	}
}
