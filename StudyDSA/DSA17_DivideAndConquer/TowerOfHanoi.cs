using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA09_AlgorithmDesignTechniques
{
	/// <summary>
	/// 분할정복 : 하노이탑 구현
	/// </summary>
	internal class TowerOfHanoi
	{
		private enum Place { Right, Middle, Left }

		/// <summary>
		/// 하노이 플레이 판
		/// </summary>
		private Stack<int>[] stick;

		public TowerOfHanoi()
		{
			stick = new Stack<int>[3];
		}

		/// <summary>
		/// 하노이탑 게임 플레이
		/// </summary>
		/// <param name="num">블럭의 개수 입력</param>
		public void PlayHanoi(int num)
		{
			for (int i = 0; i < stick.Length; i++)
			{
				stick[i] = new Stack<int>();
			}

			//왼쪽 스틱에 모든 블럭을 쌓아줌
			for(int i = 0; i < num;)
			{
				stick[0].Push(++i);
			}
			Move(num, Place.Right, Place.Left);
		}

		/// <summary>
		/// 블럭 이동 
		///	  > n을 이동하기 위해서 n-1이 이동해야 해.
		/// </summary>
		/// <param name="cnt">블럭 위치 (몇번째 블럭인지)</param>
		/// <param name="startPoint">블럭 현재 위치</param>
		/// <param name="endPoint">블럭 이동 위치</param>
		private void Move(int cnt, Place startPoint, Place endPoint)
		{
			if(cnt == 1)
			{
				int currentBlock = stick[(int)startPoint].Pop();

				stick[(int)endPoint].Push(currentBlock);

                Console.WriteLine($"[{currentBlock}이동] : {startPoint} -> {endPoint} ");
				return;
            }
			Place other = (Place)(3 - ((int)startPoint + (int)endPoint));

			Move(cnt - 1, startPoint, other); // 4 3 2 1 
			Move(1, startPoint, endPoint);
			Move(cnt - 1, other, endPoint);
		}
	}
}
