using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA07_BinarySearchTree.UserDefinition
{
	/// <summary>
	/// 이진탐색 트리 정의
	/// </summary>
	internal class BinarySearchTree<T> where T : IComparable<T>
	{
		/// <summary>
		/// 최상위 노드 (시작점)
		/// </summary>
		private Node<T> rootNode;

		public BinarySearchTree()
		{
			rootNode = null;
		}

		/// <summary>
		/// 데이터 추가
		/// </summary>
		/// <param name="item"></param>
		/// <returns>중복 허용 안 할 경우, 중복된 데이터 들어오면 false 반환함</returns>
		public bool Add(T item)
		{
			Node<T> newNode = new Node<T>(item, null, null, null);

			if(IsEmpty())
			{
				rootNode = newNode;
				return true;
			}

			Node<T> current = rootNode;
			while( current != null )
			{
				if(item.CompareTo(current.item) < 0) //현재 노드보다 item이 더 작은 경우
				{
					if(current.left != null) //현재 노드가 자식을 가지고 있는 경우 (다음 비교할 노드가 존재함)
					{
						current = current.left; //다음 노드로 이동
					}
					else //다음 비교할 노드가 자식 노드가 없으면,
					{
						current.left = newNode; //그 위치가 신규 노드의 자리가 됨.
						newNode.parent = current; 
						return true;
					}
				}
				else if (item.CompareTo(current.item) > 0)
				{
					if (current.right != null) 
					{
						current = current.right; 
					}
					else 
					{
						current.right = newNode;
						newNode.parent = current;
						return true;
					}
				}
				else //데이터가 동일함? => 중복 => 추가 취소함
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 노드 탐색
		/// </summary>
		/// <param name="item"></param>
		/// <param name="outValue"></param>
		/// <returns></returns>
		public bool TryGetValue(T item, out T outValue)
		{
			Node<T> node = FindNode(item);
			outValue = node == null ? default(T) : node.item;
			return (outValue != null);
		}

		/// <summary>
		/// 노드 찾기
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public Node<T> FindNode(T item)
		{
			if (IsEmpty() == false)
			{
				Node<T> current = rootNode;
				while (current != null)
				{
					if (item.CompareTo(current.item) < 0) //현재 노드(current.item)보다 item이 더 작은 경우
					{
						current = current.left;
					}
					else if (item.CompareTo(current.item) > 0) //현재 노드보다 item이 더 큰 경우
					{
						current = current.right;
					}
					else //현재 노드값과 찾는 값이 동일하다면? 데이터 찾음
					{
						return current;
					}
				}
			}

			return null;
		}

		public bool Remove(T item)
		{
			Node<T> node = FindNode(item);

			if(node == null) { return false; }

			ErageNode(node);
			return true;
		}

		/// <summary>
		/// 노드 제거 
		/// </summary>
		/// <param name="node"></param>
		private void ErageNode(Node<T> node)
		{
			if (node.HasNoChild) //자식이 없는 가장 마지막 레벨의 노드일 경우
			{
				if (node.IsLeftChild)
				{
					node.parent.left = null;
				}
				else if (node.IsRightChild)
				{
					node.parent.right = null;
				}
				else //자식 노드가 없음 + 왼쪽, 오른쪽 어느 쪽에도 부모가 없음 = rootNode
				{
					rootNode = null; //루트제거
				}
			}
			else if (node.HasLeftChild || node.HasRightChild) //자식이 하나만 있는 경우
			{
				Node<T> parent = node.parent; //현재 노드의 부모 노드
				Node<T> child = node.HasLeftChild ? node.left : node.right; //현재 노드의 자식 노드

				if (node.IsLeftChild == false && node.IsRightChild == false)
				{
					rootNode = child; //자식 노드를 루트 노드로 만들어 줌
					child.parent = null;
				}
				ConnectionNode(parent, child, node.IsLeftChild);
			}
			else //자식 노드가 2개인 경우, 왼쪽 자식 중 가장 큰 값과 데이터 교환 후 그 노드를 삭제해야 함.
			{
				//왼쪽 자식 중 가장 큰 값은> 현재 노드에서 왼쪽으로 한 칸 이동한 뒤 계속 오른쪽 자식으로 이동함. 
				Node<T> replaceNode = node.left;
				while(replaceNode.right != null ) { replaceNode = node.right; }

				node.item = replaceNode.item;
				ErageNode(replaceNode);

				//반대도 가능함. 
				//오른쪽으로 한 칸 이동한 뒤 왼쪽으로 계속 이동해도 결과는 동일함.
			}
		}

		private void ConnectionNode(Node<T> parent, Node<T> child, bool isLeftChild)
		{
			if (isLeftChild)
			{
				parent.left = child;
				child.parent = parent;
			}
			else
			{
				parent.right = child;
				child.parent = parent;
			}
		}


		/// <summary>
		/// 트리가 비어있는지 확인
		/// </summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			return (rootNode == null); //root에 값이 없으면 빈 트리임
		}
	}

	public class Node<T>
	{
		/// <summar/summary>
		public T item;

		/// <summary>
		/// 부모 노드에 대한 정보
		/// </summary>
		public Node<T> parent;

		/// <summary>
		/// 왼쪽 자식 노드 
		/// </summary>
		public Node<T> left;

		/// <summary>
		/// 오른쪽 자식 노드
		/// </summary>
		public Node<T> right;

		public Node(T item, Node<T> parent)
		{
			this.item = item;
			this.parent = parent;
			this.left = null;
			this.right = null;
		}

		public Node(T item, Node<T> parent, Node<T> left, Node<T> right)
		{
			this.item = item;
			this.parent = parent;
			this.left = left;
			this.right = right;
		}

		

		/// <summary>
		/// 자식이 없는지 확인
		/// </summary>
		/// <returns></returns>
		public bool HasNoChild { get { return left == null && right == null; } }

		/// <summary>
		/// 왼쪽 자식 있는지 확인
		/// </summary>
		public bool HasLeftChild { get { return left != null && right == null; } }

		/// <summary>
		/// 오른쪽 자식 있는지 확인
		/// </summary>
		public bool HasRightChild { get { return left == null && right != null; } }

		/// <summary>
		/// 현재 노드가 부모의 왼쪽 자식인지 확인
		/// </summary>
		public bool IsLeftChild { get { return parent != null && parent.left == this; } }

		/// <summary>
		/// 현재 노드가 부모의 오른쪽 자식인지 확인
		/// </summary>
		public bool IsRightChild { get { return parent != null && parent.right == this; } }
	}
}
