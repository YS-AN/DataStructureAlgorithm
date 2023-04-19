namespace DSA02_LinkedList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//linkedlist 사용해보기
			UseLinkedList useLinkedList = new UseLinkedList();
			useLinkedList.HowtoUseLinkedList();

			//linked list 구현해보기 
			TestNewDefLinkedList();
		}

		static void TestNewDefLinkedList()
		{
			DSA02_LinkedList.UserDefinition.LinkedList<string> linkedList = new DSA02_LinkedList.UserDefinition.LinkedList<string>();

			// 링크드리스트 요소 삽입
			linkedList.AddFirst("0번 앞데이터");
			linkedList.AddFirst("1번 앞데이터");
			linkedList.AddLast("0번 뒤데이터");
			linkedList.AddLast("1번 뒤데이터");
			Console.WriteLine($"{linkedList.ToString(" >> ")}\n");

			// 링크드리스트 요소 삭제
			linkedList.Remove("1번 앞데이터");
			Console.WriteLine($"{linkedList.ToString()}\n");

			// 링크드리스트 요소 존재 여부 확인
			Console.WriteLine($"1번 앞데이터 있니? {linkedList.Contains("1번 뒤데이터")}");
			Console.WriteLine($"2번 앞데이터 있니? {linkedList.Contains("2번 뒤데이터")}\n");

            // 링크드리스트 요소 탐색
            DSA02_LinkedList.UserDefinition.LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

			// 링크드리스트 노드를 통한 노드 참조
			DSA02_LinkedList.UserDefinition.LinkedListNode<string> prevNode = findNode.Prev;
			DSA02_LinkedList.UserDefinition.LinkedListNode<string> nextNode = findNode.Next;

			// 링크드리스트 노드를 통한 노드 삽입
			linkedList.AddBefore(findNode, "찾은노드 앞데이터");
			Console.WriteLine($"{linkedList.ToString(" - ")}\n");

			linkedList.AddAfter(findNode, "찾은노드 뒤데이터");
			Console.WriteLine($"{linkedList.ToString(" -> ")}\n");

			// 링크드리스트 노드를 통한 삭제
			linkedList.Remove(findNode);
			Console.WriteLine($"{linkedList.ToString("\t")}\n");

			linkedList.clear();
			Console.WriteLine($"{linkedList.ToString()}\n");

			linkedList.AddFirst("0번 앞데이터");
			linkedList.AddFirst("1번 앞데이터");
			linkedList.AddLast("0번 뒤데이터");
			linkedList.AddLast("1번 뒤데이터");
			Console.WriteLine($"{linkedList.ToString(" >> ")}\n");

			linkedList.RemoveFirst();
			linkedList.RemoveLast();
			Console.WriteLine($"{linkedList.ToString()}\n");

			
		}
	}
}