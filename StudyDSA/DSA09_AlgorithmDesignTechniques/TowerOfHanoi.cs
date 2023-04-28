using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA09_AlgorithmDesignTechniques
{
	/// <summary>
	/// 하노이탑 구현
	/// https://www.acmicpc.net/problem/11729
	/// </summary>
	internal class TowerOfHanoi
	{
		public void PlayHanoi()
		{
			int input = int.Parse(Console.ReadLine());

			int moveCnt = Convert.ToInt32(Math.Pow(2, input)) - 1;
			Console.WriteLine(moveCnt);

			StringBuilder sboPrint = new StringBuilder();
			Move(input, 1, 3, sboPrint);

			Console.WriteLine(sboPrint.ToString());
		}

		private void Move(int currentPoint, int start, int end, StringBuilder sboPrint)
		{
			if (currentPoint == 1)
			{
				sboPrint.AppendFormat("{0} {1}\n", start, end);
				return;
			}

			int other = 6 - (start + end);

			Move(currentPoint - 1, start, other, sboPrint);
			Move(1, start, end, sboPrint);
			Move(currentPoint - 1, other, end, sboPrint);
		}
	}
}
