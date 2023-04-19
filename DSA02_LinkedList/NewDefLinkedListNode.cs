using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA02_LinkedList.UserDefinition
{
	public class LinkedListNode<T>
	{
		/// <summary>
		/// 노드 소속
		/// </summary>
		private LinkedList<T> _list;
		public LinkedList<T> List { get { return _list; } }

		/// <summary>
		/// 이전 노드
		/// </summary>
		private LinkedListNode<T> _prev;
		public LinkedListNode<T> Prev { get { return _prev; } internal set { _prev = value; } }

		/// <summary>
		/// 다음 노드
		/// </summary>
		private LinkedListNode<T> _next;
		public LinkedListNode<T> Next { get { return _next; } internal set { _next = value; } }

		/// <summary>
		/// Data
		/// </summary>
		private T _item;
		public T Value { get { return _item; } set { _item = value; } }

		public LinkedListNode(T value)
		{
			this._list = null;
			this._prev = null;
			this._next = null;
			this._item = value;
		}

		public LinkedListNode(LinkedList<T> list, T value)
		{
			this._list = list;
			this._prev = null;
			this._next = null;
			this._item = value;
		}

		public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
		{
			this._list = list;
			this._prev = prev;
			this._next = next;
			this._item = value;
		}
	}
}
