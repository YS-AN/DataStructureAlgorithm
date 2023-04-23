namespace DSA05_Queue
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UseNewDefQueue(); //큐 구현

			//요세푸스 순열
			PracticeQueue practiceQueue = new PracticeQueue();
			practiceQueue.JosephusProblem<int>(new int[]{ 1,2,3,4,5,6,7,8,9 }, 3);
			practiceQueue.JosephusProblem<string>(new string[] { "가", "나", "다", "라", "마", "바", "사" }, 5);
		}

		static void UseNewDefQueue()
		{
			DSA05_Queue.Queue<int> queue = new DSA05_Queue.Queue<int>();

			for (int i = 0; i < 8;)
				queue.Enqueue(++i);

			Console.WriteLine($"PEEK : {queue.Peek()}"); //최상단  출력

			while (queue.Count > 0)
			{
				Console.Write($"{queue.Dequeue()} ");
				//output :1 2 3 4 5 6 7 8 -> FIFO
			}
			Console.WriteLine("\n");
		}
	}
}