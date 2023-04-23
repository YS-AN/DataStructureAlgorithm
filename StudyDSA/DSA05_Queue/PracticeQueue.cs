using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSA05_Queue
{
	internal class PracticeQueue
	{
		//todo.플레이어와 속도를 입력 받아서, 속도가 빠른 순서대로 출력
		public void SortByQuick(List<Player> players)
		{

		}

		/// <summary>
		/// 요세푸스 순열
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data">순열에 쓸 데이터</param>
		/// <param name="num">띌 간격</param>
		public void JosephusProblem<T>(T[] data, int num)
		{
			if (num <= 0)
				return;

			int head = --num;
			int tail = 0;

			int len = data.Length;

			while (head != tail)
			{
				Console.Write($"{data[head]} >> ");
				head = (head + num) % len;
			}
			Console.Write($"{data[head]}");
            Console.WriteLine("");
        }
	}

	public class Player
	{
		string Name { get; set; }
		public int Speed { get; set; }

		public Player(string name, int speed) 
		{ 
			Name = name;
			Speed = speed;
		}
	}

	public class Solution
	{
		public int solution(int[] numbers, int k)
		{
			int point = 2;
			int len = numbers.Length;

			for(int i=0; i < k; i++)
			{
				point = (point + 2) % len;
			}
			return numbers[point];
		}
	}
}
