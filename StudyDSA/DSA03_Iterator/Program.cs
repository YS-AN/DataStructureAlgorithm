using DSA03_Iterator;

namespace DSA03_Iterator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IteratorInList();

			IteratorInLinkedList();

		}

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

		static void IteratorInLinkedList()
		{
			DSA03_Iterator.LinkedList<int> list = new DSA03_Iterator.LinkedList<int>();
			for (int i = 0; i < 5;) { list.AddLast(++i); }

			foreach (int i in list)
			{
				Console.WriteLine(i);
			}
		}
	}
}