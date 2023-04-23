using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA05_Queue
{
	/// <summary>
	/// 어댑터 패턴으로 구현한 큐
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal class AdapterQueue<T>
	{
		private LinkedList<T> container;

		public int Count { get { return container.Count; } }

		public AdapterQueue()
		{
			container = new LinkedList<T>();
		}

		/// <summary>
		/// 데이터 삽입
		/// </summary>
		/// <param name="item"></param>
		public void Enqueue(T item)
		{
			container.AddLast(item);
		}

		/// <summary>
		/// 데이터 삭제
		/// </summary>
		/// <returns></returns>
		public T Dequeue()
		{
			T value = container.First<T>();
			container.RemoveFirst();
			return value;
		}

		/// <summary>
		/// 최전방 데이터 반환
		/// </summary>
		/// <returns></returns>
		public T Peek()
		{
			return container.First<T>();
		}
	}
}
