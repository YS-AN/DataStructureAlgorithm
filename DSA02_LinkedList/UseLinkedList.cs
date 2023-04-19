using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA02_LinkedList
{
	/// <summary>
	/// <링크드리스트 사용>
	/// </summary>
	internal class UseLinkedList
	{
		public void HowtoUseLinkedList()
		{
			LinkedList<string> linkedList = new LinkedList<string>();

			// 링크드리스트 요소 삽입
			// 링크로 연결되어 있기 때문에 개수보다는 위치가 더 중요함. 
			linkedList.AddFirst("0번 앞데이터");
			linkedList.AddFirst("1번 앞데이터");
			linkedList.AddLast("0번 뒤데이터");
			linkedList.AddLast("1번 뒤데이터");

			// 링크드리스트 요소 삭제
			linkedList.Remove("1번 앞데이터");

			// 링크드리스트 요소 탐색
			LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

			// 링크드리스트 노드를 통한 노드 참조
			LinkedListNode<string> prevNode = findNode.Previous;
			LinkedListNode<string> nextNode = findNode.Next;

			// 링크드리스트 노드를 통한 노드 삽입
			linkedList.AddBefore(findNode, "찾은노드 앞데이터");
			linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

			// 링크드리스트 노드를 통한 삭제
			linkedList.Remove(findNode);
		}
	}
}