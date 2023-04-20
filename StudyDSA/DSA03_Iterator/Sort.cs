using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA03_Iterator
{
	internal class Sort
	{
		public IList<T> Ascending<T>(IList<T> data) where T : IComparable<T>
		{
			CompareData(data, true);
			return data;
		}

		public IEnumerable<T> Descending<T>(IList<T> data) where T : IComparable<T>
		{
			CompareData(data, false);
			return data;
		}

		private void CompareData<T>(IList<T> data, bool chkStand) where T : IComparable<T>
		{
			for (int i = 0; i < data.Count; i++)
			{
				int cmpIndex = i;

				for (int j = i + 1; j < data.Count; j++)
				{
					if ((data[cmpIndex].CompareTo(data[j]) > 0) == chkStand)
					{
						cmpIndex = j;
					}
				}

				if(i != cmpIndex)
				{
					T tmp = data[cmpIndex];
					data[cmpIndex] = data[i];
					data[i] = tmp;
				}
			}
		}
	}
}
