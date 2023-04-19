using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA02_LinkedList.UserDefinition
{
	public class LinkedList<T>
	{
		/// <summary>
		/// 시작 위치 (Frist)
		/// </summary>
		private LinkedListNode<T> _head;
		public LinkedListNode<T> First { get { return _head; } }

		/// <summary>
		/// 끝 위치 (Last)
		/// </summary>
		private LinkedListNode<T> _tail;
		public LinkedListNode<T> Last { get { return _tail; } }

		/// <summary>
		/// 현재 가지고 있는 노드 개수
		/// </summary>
		private int _count;
		public int Count { get { return _count; } }

		public LinkedList()
		{
			this._head = null;
			this._tail = null;
			_count = 0;
		}

		/// <summary>
		/// linkedlist 맨 앞에 추가
		/// </summary>
		/// <param name="value">노드 데이터</param>
		/// <returns></returns>
		public LinkedListNode<T> AddFirst(T value)
		{
			// 1.새로운 노드 추가
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

			// 2.연결 구조 변경
			if(_head != null) //2-1.Head 노드가 있을 때
			{
				//newNode의 뒤와 기존 시작 위치인 _head의 앞을 연결
				_head.Prev = newNode;
				newNode.Next = _head; 
			}
			else //2-2.Head 노드가 없을 때 (linkedList 처음 만들었을 때)
			{
				_tail = newNode; //시작과 끝을 모두 newNode로 지정함
			}
			
			// 3.새로운 노드를 head 노드로 저장
			_head = newNode;

			_count++;
			return newNode;
		}

		/// <summary>
		/// linkedlist 맨 뒤에 추가
		/// </summary>
		/// <param name="value">노드 데이터</param>
		/// <returns></returns>
		public LinkedListNode<T> AddLast(T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

			if(_tail != null)
			{
				_tail.Next = newNode;
				newNode.Prev = _tail;
			}
			else
			{
				_head = newNode;
			}
			_tail = newNode;

			_count++;
			return newNode;
		}

		/// <summary>
		/// 지정한 노드 앞에 추가
		/// </summary>
		/// <param name="node">기준 노드</param>
		/// <param name="value">추가 할 값</param>
		/// <returns></returns>
		public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

			newNode.Next = node; //newNode의 next를 기준 노드를 가리키도록 함.

			if (node == _head) //기준 노드가 첫번째 노드면? 헤드 노드를 변경해줌
			{
				_head = newNode;
			}
			else //기준 노드가 첫번째 노드가 아니다? = 기준 노드의 prev가 있음
			{
				newNode.Prev = node.Prev; //노드의 prev에 새로운 노드를 넣어줌. 
				node.Prev.Next = newNode; //기준 노드의 이전 노드의 next를 newNode로 바꿔줌.
			}
			node.Prev = newNode; //기준 노드의 prev를 newNode로 변경함

			_count++;
			return newNode;
		}

		/// <summary>
		/// 지정한 노드 뒤에 추가
		/// </summary>
		/// <param name="node">기준 노드</param>
		/// <param name="value">추가 할 값</param>
		/// <returns></returns>
		public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

			newNode.Prev = node; //newNode의 prev를 기준 노드를 가리키도록 함.

			if (node == _tail) //기준 노드가 마지막 노드면? 테일 노드를 변경해줌
			{
				_tail = newNode;
			}
			else //기준 노드가 마지막 노드가 아니다? = 기준 노드의 next가 있음
			{
				newNode.Next = node.Next; //노드의 next에 새로운 노드를 넣어줌. 
				node.Next.Prev = newNode; //기준 노드의 다음 노드의 prev가 newNode 가리키도록 함
			}
			node.Next = newNode; //기준 노드의 prev를 newNode로 변경함

			_count++;
			return newNode;
		}

		/// <summary>
		/// 노드 삭제
		/// </summary>
		/// <param name="node"></param>
		/// <exception cref="InvalidOperationException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public void Remove(LinkedListNode<T> node)
		{
			//노드가 연결리스트에 포함되어 있지 않은 노드인 경우 > 예외처리
			//노드를 생성할 때마다 this(node.List)를 넣어 줌. 
			//  -> node.List가 this가 아니면 node.List에 소속이 아니라고 판단할 수 있음.
			//     (node.List에 포함되어 있는지를 판단하는 것이 아니라, 역으로 list를 가지고 있는지를 판단하는 것(
			if(node.List != this)
				throw new InvalidOperationException("포함되어 있지 않은 노드");

			//노드가 null인 경우 > 예외처리
			if (node == null)
				throw new ArgumentNullException(nameof(node));

			if (node.Prev == null) //삭제할 노드의 이전 노드가 없다? => 삭제할 노드가 첫번째 노드란 의미임
			{
				_head = node.Next;
			}
			else
			{
				//삭제할 노드의 이전 노드에서 가리키는 next를 삭제할 노드의 다음 노드 주소를 넣어줘야 함
				node.Prev.Next = node.Next;
			}

			if (node.Next == null) //삭제할 노드의 다음 노드가 없다? => 삭제할 노드가 마지막 노드란 의미임
			{
				_tail = node.Prev;
			}
			else
			{
				node.Next.Prev = node.Prev;  
			}

			_count--;
		}

		/// <summary>
		/// 데이터 기준으로 노드 삭제
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Remove(T value)
		{
			LinkedListNode<T> findNode = Find(value);

			if(findNode != null)
			{
				Remove(findNode);
				return true;
			}
			return false;
		}

		/// <summary>
		/// 리스트의 첫번째 노드를 삭제한다
		/// </summary>
		/// <returns></returns>
		public void RemoveFirst()
		{
			if(_head.Next != null)
			{
				_head.Next.Prev = null;
			}
			_head = _head.Next;

			_count--;
		}

		/// <summary>
		/// 리스트의 마지막 노드를 삭제한다
		/// </summary>
		/// <returns></returns>
		public void RemoveLast()
		{
			if (_tail.Prev != null)
			{
				_tail.Prev.Next = null;
			}
			_tail = _tail.Prev;

			_count--;
		}

		/// <summary>
		/// 데이터 검색 (없으면 null반환)
		/// </summary>
		/// <param name="value">찾을 데이터</param>
		/// <returns></returns>
		public LinkedListNode<T> Find(T value)
		{
			LinkedListNode<T> target = _head;
			EqualityComparer<T> compare = EqualityComparer<T>.Default; //기본 비교

			//target가 null이 아니고, 찾는 값이 아닐 경우, 다음 노드로 이동함
			while (target != null && (!compare.Equals(value, target.Value)))
			{
				target = target.Next;
			}
			return target;
		}

		/// <summary>
		/// 리스트에 해당 데이터가 포함되어 있는지 확인한다
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(T value)
		{
			return (Find(value) != null);
		}

		public void clear()
		{
			_head = null;
			_tail = null;
			_count = 0;
		}

		public string ToString(string separator = ", ")
		{
			if(_count > 0)
			{
				StringBuilder sboDataStr = new StringBuilder();

				LinkedListNode<T> node = _head;

				while (node.Next != _tail)
				{
					sboDataStr.Append(node.Value);
					sboDataStr.Append(separator);

					node = node.Next;
				}
				sboDataStr.Append(node.Value);

				return sboDataStr.ToString();
			}
			return "(EMPTY)";	
		}
	}
}
