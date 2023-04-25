using DSA06_Heap.UserDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA06_Heap
{
	internal class PracticeHeap
	{
		/// <summary>
		/// 골든타임을 입력받아서 급한 환자부터 치료하는 응급실
		/// </summary>
		public void SortEmergency()
		{
			DSA06_Heap.UserDefinition.PriorityQueue<string, int> patient = new DSA06_Heap.UserDefinition.PriorityQueue<string, int>();

			patient.Enquere("팔골절", 5);
			patient.Enquere("뇌진탕", 3);
			patient.Enquere("코피", 10);
			patient.Enquere("교통사고", 1);

			Console.WriteLine("[응급실 치료 순서]");
			while (patient.Count > 0)
			{
				Console.WriteLine(patient.Dequere());
			}
		}

		/// <summary>
		/// 우선순위 중간값 구하기
		/// </summary>
		

		/*
		 * Heap을 이용한 중간 값 찾기
		 * 여러 데이터를 정렬 시켜둔 상황에서 중간값을 찾으면 쉽게 찾을 수 있음.
		 * 하지만 새로운 데이터가 추가 된 경우에는 다시 데이터를 정렬해야 만 중간 값을 찾아야함.
		 * 추가, 삭제가 있을 때 마다 데이터를 재정렬해줘야 함 (O(nlogn)임
		 * 
		 * 중간값이라는것은 왼쪽 n개 오른쪽에 n개 있으면 중간 값이라고 할 수 있음.
		 * n < 중간값 < n  -> 값 추가 : n < 중간값 < n+2이면, 더이상 중간값이라고 할 수 없음
		 * 
		 * 2개 이상 차이면 차이다는 2개 중 
		 * 큰 값이 2개이상 많으면 가장 작은 값이 중간 값
		 * 작은 값이 2개이상 차이나면 가장 큰 값이 중간 값이 됨. 
		 */
		public int GetMidData(int[] values)
		{
			DSA06_Heap.UserDefinition.PriorityQueue<int, int> minQ = new DSA06_Heap.UserDefinition.PriorityQueue<int, int>(Comparer<int>.Create((a, b) => (b - a)));
			DSA06_Heap.UserDefinition.PriorityQueue<int, int> maxQ = new DSA06_Heap.UserDefinition.PriorityQueue<int, int>();

			int midVal = values[0];

			for (int i=1; i< values.Length; i++)
			{
				if (values[i] > midVal)
				{
					maxQ.Enquere(values[i], values[i]);
				}
				else
				{
					minQ.Enquere(values[i], values[i]);
				}

				if(Math.Abs(maxQ.Count- minQ.Count) > 1)
				{
					if(maxQ.Count > minQ.Count)
					{
						minQ.Enquere(midVal, midVal);
						midVal = maxQ.Dequere();
					}
					else
					{
						maxQ.Enquere(midVal, midVal);
						midVal = minQ.Dequere();
					}
				}

			}

			return midVal;

		}

	}
}
