using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA09_AlgorithmDesignTechniques
{
	/// <summary>
	/// N과 M 3
	/// https://www.acmicpc.net/problem/15651
	/// </summary>
	internal class Print_NandM03
	{
		public void NandM03()
		{
			string input = Console.ReadLine();

			string[] value = input.Split();

			int n = int.Parse(value[0]);
			int m = int.Parse(value[1]);

			StringBuilder result = PrintSequence(n, m);
			Console.WriteLine(result.ToString());
		}

		private StringBuilder PrintSequence(int n, int m)
		{
			StringBuilder retValue = new StringBuilder();

			int max = Convert.ToInt32(Math.Pow(n, m));

			int[] replaceArr = new int[n];
			for (int i = 0; i < n;)
				replaceArr[i] = ++i;

			int[] data = new int[m];

			int[] divideNums = new int[--m];
			for (int i = 0; i < m; i++)
				divideNums[i] = Convert.ToInt32(Math.Pow(n, m - i));

			for (int j = 0; j < max; j++)
			{
				for (int i = 0; i < m; i++)
					retValue.AppendFormat("{0} ", replaceArr[(j / divideNums[i]) % n]);

				retValue.AppendFormat("{0}\n", replaceArr[j % n]);
			}

			return retValue;
		}
	}
}