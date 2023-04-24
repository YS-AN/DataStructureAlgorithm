using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA06_Heap
{
	internal class UseHeap
	{
		public void TestPriorityQueue()
		{
			PriorityQueue<string, int> priorityQ = new PriorityQueue<string, int>();
			priorityQ.Enqueue("감자", 3);
			priorityQ.Enqueue("양파", 5);
			priorityQ.Enqueue("당근11", 1);
			priorityQ.Enqueue("당근22", 1);
			priorityQ.Enqueue("토마토", 2);
			priorityQ.Enqueue("마늘", 4);

			while(priorityQ.Count > 0)
			{
                Console.WriteLine(priorityQ.Dequeue()); //우선수위가 높은 순서대로 출력 됨.
			}

			PriorityQueue<string, int> desendingPQ = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => (b -a))); // 우선순위를 내림차순으로 정렬하기 위한 방법
			desendingPQ.Enqueue("감자", 3);
			desendingPQ.Enqueue("양파", 5);
			desendingPQ.Enqueue("당근11", 1);
			desendingPQ.Enqueue("당근22", 1);
			desendingPQ.Enqueue("토마토", 2);
			desendingPQ.Enqueue("마늘", 4);

			while (desendingPQ.Count > 0)
			{
				Console.WriteLine(desendingPQ.Dequeue()); //우선수위가 낮은 순서대로 출력 됨.
			}
		}
	}
}
