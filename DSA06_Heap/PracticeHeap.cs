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
		public void GetMidData()
		{
			//DSA06_Heap.UserDefinition.PriorityQueue<int, int> minQ = new DSA06_Heap.UserDefinition.PriorityQueue<int, int>();
			//DSA06_Heap.UserDefinition.PriorityQueue<int, int> maxQ = new DSA06_Heap.UserDefinition.PriorityQueue<int, int>((a,b) => (b-a));
			//
			//for (int i = 0; i < 10000;)
			//{
			//	priorityQ.Enquere(++i, i);
			//}
			//
			//Node<int, int> midNode = priorityQ.MidNode();
			//Console.WriteLine($"중간 값 : [{midNode.priority},{midNode.elemenet}]");
		}


	}
	
}
