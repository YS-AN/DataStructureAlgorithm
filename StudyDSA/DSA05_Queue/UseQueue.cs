using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA05_Queue
{
	internal class UseQueue
	{
		public void TestQueue()
		{
			Queue<int> queue = new Queue<int>();

			for(int i = 0; i < 10; i++)
			{
				queue.Enqueue(i); //큐에 값을 넣어 줌
			}

            Console.WriteLine(queue.Peek()); //최전방 있는 값 출력

            while (queue.Count > 0)
			{
                Console.WriteLine(queue.Dequeue); //큐에 있는 값을 뺌
            }
		}
	}
}
