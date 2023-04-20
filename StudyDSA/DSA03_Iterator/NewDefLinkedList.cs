using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DSA02_LinkedList.UserDefinition;

namespace DSA03_Iterator
{
	internal class LinkedList<T> : DSA02_LinkedList.UserDefinition.LinkedList<T>, IEnumerable<T>
	{
		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		/// <summary>
		/// linked list의 반복기
		///	> 현재 어떤 노드를 가리키고 있는 지가 가장 중요한 포인트
		/// </summary>
		public struct Enumerator : IEnumerator<T>
		{
			private LinkedList<T> linkedList;
			private DSA02_LinkedList.UserDefinition.LinkedListNode<T> node;
			private T _current;

			public T Current { get { return _current; } }

			public Enumerator(LinkedList<T> linkedList)
			{
				this.linkedList = linkedList;
				this.node = linkedList.First;
				_current = default(T);
			}

			object IEnumerator.Current => throw new NotImplementedException();

			public void Dispose()
			{
				Console.WriteLine("Dispose 호출");
			}

			public bool MoveNext()
			{
				if (node == null) //node가 null이면 마지막 노드란 의미임.
				{
					_current = default(T);
					return false;
				}
				_current = node.Value;
				node = node.Next;
				return true;
			}

			public void Reset()
			{
				node = null;
				_current = default(T);
			}
		}
	}
}
