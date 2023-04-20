using DSA03_Iterator;

namespace DSA03_Iterator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IteratorInList();

			IteratorInLinkedList();

			SortData();

			GetAverage();
		}

		/// <summary>
		/// List 반복자
		/// </summary>
		static void IteratorInList()
		{
			DSA03_Iterator.List<int> list = new DSA03_Iterator.List<int>();
			for (int i = 0; i < 5;) { list.Add(++i); }

			IEnumerator<int> iter = list.GetEnumerator();
			Console.WriteLine(iter.Current);

			//foreach 내부 구현 동작 방식과 동일함 (아래 코드를 단순화 하면 foreach임)----
			iter.Reset();
			while (iter.MoveNext())
			{
				Console.WriteLine(iter.Current);
			}
			Console.WriteLine(iter.Current);
			iter.Dispose();
			//------------------------------------------------------------------------

			foreach (int i in list)
			{
				Console.WriteLine(i);
			}
		}

		/// <summary>
		/// LinkedList 반복자
		/// </summary>
		static void IteratorInLinkedList()
		{
			DSA03_Iterator.LinkedList<int> list = new DSA03_Iterator.LinkedList<int>();
			for (int i = 0; i < 5;) { list.AddLast(++i); }

			foreach (int i in list)
			{
				Console.WriteLine(i);
			}
		}

		/// <summary>
		/// Sort(배열), Sort(리스트) 둘 모두 정렬 가능한 하나의 함수 구현
		/// </summary>
		static void SortData()
		{
			Sort sort = new Sort();

			System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>() { 4, 6, 1, 29, 0, 2, 10, 30, 3 };
			Print(sort.Ascending(list));

			string[] arr = new string[5] { "홍길동", "안예슬", "최영희", "김하늘", "박철수" };
			Print(sort.Ascending(arr)); Console.WriteLine(Average(list));
		}

		static void Print<T>(IList<T> data)
		{
			foreach (var item in data)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// 평균 구하기
		/// </summary>
		private static void GetAverage()
		{
			List<int> list = new List<int>() { 4, 6, 1, 29, 0, 2, 10, 30, 3 };
			Console.WriteLine($"평균 : {Average(list)}");

			int[] arr = { 4, 6, 1, 29, 0, 2, 10, 30, 3 };
			Console.WriteLine($"평균 : {Average(arr)}");
		}

		/// <summary>
		/// int 자료구조의 평균을 구하는 Average(자료구조) 구현
		/// </summary>
		/// <param name="data">데이터</param>
		/// <returns></returns>
		static int Average(IEnumerable<int> data)
		{
			int sum = 0;
			foreach(var item in data)
			{
				sum += item;
			}

			return (sum / data.Count());
		}
	}
}