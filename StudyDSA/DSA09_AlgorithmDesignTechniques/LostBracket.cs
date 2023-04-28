using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA09_AlgorithmDesignTechniques
{
	/// <summary>
	/// 잃어버린 괄호
	/// https://www.acmicpc.net/problem/1541
	/// </summary>
	internal class LostBracket
	{
		public void GetMinValue()
		{
			string inputStr = Console.ReadLine();

			var dataArr = inputStr.Split('-');

			int sum = CalculateSum(dataArr[0]);

			for (int i = 1; i < dataArr.Length; i++)
			{
				sum += (CalculateSum(dataArr[i]) * -1);
			}
			Console.WriteLine(sum);
		}

		private static int CalculateSum(string inputStr)
		{
			var arr = inputStr.Split("+");

			int sum = 0;
			foreach (var item in arr)
				sum += int.Parse(item);

			return sum;
		}
	}
}
