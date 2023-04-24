using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA06_Heap.UserDefinition
{
	internal class PriorityQueue<TElement, TPriority> where TPriority : IComparable
	{
		/// <summary>
		/// 리스트 노드 : 리스트를 이용한 어덥터 
		///				(노드가 몇개가 될지 모르니까 List로 만듦
		///					> 노드를 계속 확장해서 받는 로직을 구현할 필요 없이 List에 있는 걸 활용함 > 어덥터 장점)
		/// </summary>
		private List<Node<TElement, TPriority>> nodes;

		/// <summary>
		/// 우선순위 정렬 기준
		/// </summary>
		private IComparer<TPriority> comparer;

		public int Count { get { return this.nodes.Count; } }

		public PriorityQueue()
		{
			this.nodes = new List<Node<TElement, TPriority>>();
			this.comparer = Comparer<TPriority>.Default; //특별한 경우 아니면 오름차순으로 정렬함
		}

		/// <summary>
		/// 비교 연산자를 지정하여 초기화
		/// </summary>
		/// <param name=""></param>
		public PriorityQueue(IComparer<TPriority> comparer)
		{
			this.nodes = new List<Node<TElement, TPriority>>();
			this.comparer = comparer;
		}

		/// <summary>
		/// 데이터 삽입
		/// </summary>
		/// <param name="element">값</param>
		/// <param name="priority">우선순위</param>
		public void Enquere(TElement element, TPriority priority)
		{
			Node<TElement, TPriority> newNode = new Node<TElement, TPriority>() { elemenet = element, priority = priority };

			nodes.Add(newNode);
			int newNodeIndex = nodes.Count - 1; //일단 가장 마지막에 저장함. 

			//힙상태가 유지되도록 노드 우선순위를 비교하여 노드 승격 작업을 반복함
			while(newNodeIndex > 0 ) //최상단 부모 노드는 비교할 필요 없기 때문에 0보다 큰수일 때만 수행함
			{
				int parentINdex = GetParentIndex(newNodeIndex);
				Node<TElement, TPriority> parentNode = nodes[parentINdex];

				//신규 노드의 우선순위가 부모 노드의 우선순위보다 높은 경우
				if (IsGreaterThanLeft(newNode.priority, parentNode.priority)) //newNode.priority < parentNode.priority
					{
					//부모 노드와 신규 노드의 위치 변경
					nodes[newNodeIndex] = parentNode;
					nodes[parentINdex] = newNode;
					newNodeIndex = parentINdex;
				}
				else
				{
					break; //신규 노드의 우선순위가 부모 노드보다 낮으면, 힙상태가 유지되는 경우임 > 작업 종료
				}
			}
		}

		/// <summary>
		/// 데이터 삭제
		/// </summary>
		/// <returns></returns>
		public TElement Dequere()
		{
			Node<TElement, TPriority> rootNode = nodes[0]; //가장 최상위 우선순위를 반환하면 되니까 0번지를 반환하면 돼

			//반환 후 처리 필요 

			//가장 마지막 노드를 최상단으로 이동함
			Node<TElement, TPriority> lastNode = nodes[nodes.Count - 1];
			nodes[0] = lastNode;
			nodes.RemoveAt(nodes.Count - 1);

			//힙상태가 유지 될 때까지 최상단으로 이동한 노드를 이동시킴 
			int index = 0; 
			while( index < nodes.Count ) //가장 마지막 노드는 자식이 없기 때문에 비교할 필요 없음. > Count보다 작을 때 까지만 수행하도록 하마
			{
				int leftIndex = GetLeftChildIndex(index);
				int rightIndex = GetRightChildIndex(index);

				//자식이 없는 경우 (최말단 노드)
				if (rightIndex >= nodes.Count && leftIndex >= nodes.Count) 
				{
					break; //가장 마지막까지 내려왔으니 할 일 없음. > 종료
				}

				int childIndex = -1;
				if (rightIndex < nodes.Count) //자식이 둘 다 있는 경우
				{
					//왼쪽 자식과 오른쪽 자식 중 우선순위가 더 낮은 자식을 추출함
					childIndex = IsGreaterThanLeft(nodes[leftIndex].priority, nodes[rightIndex].priority) ? leftIndex : rightIndex;
				}
				else if (leftIndex < nodes.Count) //자식이 하나만 있는 경우 (=왼쪽 자식만 있음) -> 완전 이진트리 형태라 가능
				{
					childIndex = leftIndex; //왼쪽 노드만 있으니까 왼쪽 노드 우선순위와 비교함
				}

				//자식과 부모의 우선순위 비교 > 부모가 더 우선순위가 낮은 경우에는 자식과 부모 위치 바꿈
				if (IsGreaterThanLeft(nodes[childIndex].priority, nodes[index].priority))
				{
					index = changeNode(index, childIndex, lastNode);
				}
				else //부모가 더 우선순위 높음 == 힙 상태 유지 > 종료
				{
					break;
				}
			}
			return rootNode.elemenet;
		}

		/// <summary>
		/// 우선순위가 가장 높은 데이터 반환
		/// </summary>
		/// <returns></returns>
		public TElement Peek()
		{
			return nodes[0].elemenet;
		}

		/// <summary>
		/// 부모노드의 인덱스 반환
		/// </summary>
		/// <param name="childIndex"></param>
		/// <returns></returns>
		private int GetParentIndex(int childIndex)
		{
			return (childIndex - 1) / 2;
		}

		/// <summary>
		/// 왼쪽 자식 노드 인덱스 반환
		/// </summary>
		/// <param name="parentIndex"></param>
		/// <returns></returns>
		private int GetLeftChildIndex(int parentIndex)
		{
			return parentIndex * 2 + 1;
		}

		/// <summary>
		/// 오른쪽 자식 노드 인덱스 반환
		/// </summary>
		/// <param name="parentIndex"></param>
		/// <returns></returns>
		private int GetRightChildIndex(int parentIndex)
		{
			return parentIndex * 2 + 2;
		}

		/// <summary>
		/// 자식노드와 부모노드 위치 변경
		/// </summary>
		/// <param name="parentINdex">변경될 부모노드 인덱스</param>
		/// <param name="childIndex">변경될 자식 노드 인덱스</param>
		/// <param name="currentNode">현재 노드</param>
		/// <returns></returns>
		private int changeNode(int parentINdex, int childIndex, Node<TElement, TPriority> currentNode)
		{
			nodes[parentINdex] = nodes[childIndex];
			nodes[childIndex] = currentNode;
			return childIndex;
		} 

		/// <summary>
		/// 우선순위 값 비교 : left보다 right값이 더 큰지 확인함
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		private bool IsGreaterThanLeft(TPriority left, TPriority right)
		{
			return right.CompareTo(left) > 0;
		}
	}

	public struct Node<TElement, TPriority>
	{
		/// <summary>
		/// 실제 데이터
		/// </summary>
		public TElement elemenet;

		/// <summary>
		/// 우선순위
		/// </summary>
		public TPriority priority;
	}
}
