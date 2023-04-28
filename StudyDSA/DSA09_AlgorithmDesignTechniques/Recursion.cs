using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA09_AlgorithmDesignTechniques
{
	/// <summary>
	/// 재귀
	/// </summary>
	internal class Recursion
	{
		/*
			Recursion recursion = new Recursion();
			recursion.DoRecursion();

			
		 */
		public void DoRecursion()
		{
			int num = 10;
			Factorial(num);
            Console.WriteLine($"재귀함수 종료 : {num}");
        }

		/// <summary>
		/// (재귀함수) 정수를 1이 될 때까지 차감하며 곱하는 함수
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		int Factorial(int x)
		{
			Console.Write($"{x}  ");

			if (x == 1) //종료 조건
				return 1;
			else
				return x * Factorial(x - 1); //자신을 다시 호출함
		}
	}
}