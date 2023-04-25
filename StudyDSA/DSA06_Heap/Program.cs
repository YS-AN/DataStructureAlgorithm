namespace DSA06_Heap
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UseHeap	useHeap = new UseHeap();
			useHeap.TestPriorityQueue();
			Console.WriteLine();

			PracticeHeap practiceHeap = new PracticeHeap();
			practiceHeap.SortEmergency();
			Console.WriteLine();

			int[] values01 = new int[10000];
			for (int i = 0; i < 10000; ) { values01[i] = ++i; }
			Console.WriteLine(practiceHeap.GetMidData(values01));
			Console.WriteLine();

			Random random = new Random(Guid.NewGuid().GetHashCode());

			int[] values02 = new int[10];
			for (int i = 0; i < 10; i++) { values02[i] = random.Next(1, 500); }
			
			//랜덤 데이터 확인
			foreach(var item in values02) { Console.WriteLine(item); }
			Console.WriteLine();

			Console.WriteLine(practiceHeap.GetMidData(values02)); //중간값 출력
		}
	}
}