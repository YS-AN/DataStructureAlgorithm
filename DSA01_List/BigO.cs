using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA01_List
{
	internal class BigO
	{
		/// <summary>
		/// O(1)
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public int Case1(int n)
		{
			int sum = 0;
			sum = n * n;
			return sum;
		}

		/// <summary>
		/// O(n)
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public int Case2(int n)
		{
			int sum = 0;
			for(int i=0; i<n; i++)
			{
				sum += n;
			}
			return sum;
		}

		/// <summary>
		/// O(n^2)
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public int Case3(int n)
		{
			int sum = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					sum++;
				}
			}
			return sum;
		}
	}
}
