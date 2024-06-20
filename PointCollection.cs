using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12_4
{
	public class PointCollection<T>
	{
		public T? Data { get; set; }
		public PointCollection<T>? Next { get; set; }
		public PointCollection<T>? Pred { get; set; }

		public PointCollection()
		{
			this.Data = default(T);
			this.Pred = null;
			this.Next = null;
		}

		public PointCollection(T data)
		{
			this.Data = data;
			this.Pred = null;
			this.Next = null;
		}

		public override string? ToString()
		{
			return Data == null ? "" : Data.ToString();
		}

		public override int GetHashCode()
		{
			return Data == null ? 0 : Data.GetHashCode();
		}
	}
}
