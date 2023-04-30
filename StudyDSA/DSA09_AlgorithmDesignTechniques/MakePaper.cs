using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA09_AlgorithmDesignTechniques
{
	/// <summary>
	/// 색종이 만들기
	/// https://www.acmicpc.net/problem/2630
	/// </summary>
	internal class MakePaper
	{
		public void GetMakePaper(string[] args)
		{
			int size = int.Parse(Console.ReadLine());

			int[,] paper = new int[size, size];
			for (int i = 0; i < size; i++)
			{
				string dataStr = Console.ReadLine();
				var data = dataStr.Split(" ");

				for (int j = 0; j < size; j++)
					paper[i, j] = Convert.ToInt32(data[j]);
			}

			int white = 0;
			int blue = 0;
			CheckedPaper(paper, 0, 0, size, ref white, ref blue);

			Console.WriteLine(white);
			Console.WriteLine(blue);
		}

		private void CheckedPaper(int[,] paper, int width, int height, int size, ref int white, ref int blue)
		{
			if (size == 1)
			{
				if (paper[height, width] == 0) { white++; }
				else { blue++; }
				return;
			}

			int color = paper[height, width];
			if (IsSameColor(paper, width, height, size))
			{
				if (color == 0) { white++; }
				else { blue++; }
				return;
			}

			CheckedPaper(paper, width, height, size / 2, ref white, ref blue);
			CheckedPaper(paper, width, height + size / 2, size / 2, ref white, ref blue);
			CheckedPaper(paper, width + size / 2, height, size / 2, ref white, ref blue);
			CheckedPaper(paper, width + size / 2, height + size / 2, size / 2, ref white, ref blue);
		}

		private bool IsSameColor(int[,] paper, int width, int height, int size)
		{
			int color = paper[height, width];

			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					if (color != paper[height + i, width + j])
						return false;

			return true;
		}
	}
}
