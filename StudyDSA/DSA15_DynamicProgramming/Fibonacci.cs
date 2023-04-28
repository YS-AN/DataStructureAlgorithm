using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA15_DynamicProgramming
{
	/// <summary>
	/// 포보나치 수열 
	/// </summary>
	internal class Fibonacci
	{
		public long DoFibonacci(long num)
		{
			if (num <= 1)
				return num;
			else
				return (DoFibonacci(num - 2) + DoFibonacci(num - 1));
		}
	}
}
