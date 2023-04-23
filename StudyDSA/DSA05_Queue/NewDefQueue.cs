using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSA05_Queue
{
	/// <summary>
	/// 환형 큐 구현
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal class Queue<T>
	{
		private const int InitCapacity = 4;

		/// <summary>
		/// 큐 안에 들어 있는 값
		/// </summary>
		private T[] array;

		/// <summary>
		/// 가장 앞의 위치 (전단)
		/// </summary>
		private int head;

		/// <summary>
		/// 가장 뒤의 위치 (후단)
		/// </summary>
		private int tail;

		/// <summary>
		/// 현재 큐에 들어있는 데이터 개수
		/// </summary>
		public int Count { get { return (head <= tail) ? tail - head : tail - head + array.Length; } } //마지막에 더하기 하면 빈공간만큼 추가가 됨

		public Queue() 
		{
			array = new T[InitCapacity];
			head = 0;
			tail = 0;
		}

		/// <summary>
		/// 큐가 비어있는지 확인
		/// </summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			//head와 tail의 위치가 같다? 비어있다고 취급함. 
			return head == tail; 
		}

		/// <summary>
		/// 큐가 다 찼는지 확인
		/// </summary>
		/// <returns></returns>
		public bool IsFull()
		{
			return head > tail ? (head == tail + 1) : (head == 0 && tail == array.Length - 1);
			//tail +1 % array.Length
			//
		}

		/// <summary>
		/// 최전방 자료 반환
		/// </summary>
		/// <returns></returns>
		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[head]; ;
		}

		/// <summary>
		/// 큐에 데이터 추가
		/// </summary>
		/// <param name="item"></param>
		public void Enqueue(T item)
		{
			/* 큐의 크기가 정해져 있다면 큐가 꽉 차면 예외 처리를 하는 방법으로 구현함 ( -> 고전 큐 방식)
			if(IsFull())
				throw new InvalidOperationException();
			*/

			//요즘 : 큐가 꽉 차면 데이터를 늘려주는 방식으로 구현함. (메모리가 허락하는 한 무한정으로 사이즈 늘리기 가능해짐)
			if (IsFull())
				GrowQueue();
			array[tail] = item;
			MoveNext(ref tail);
		}

		private void GrowQueue()
		{
			int newCapacity = array.Length * 2;
			T[] newArray = new T[newCapacity];

			if(head < tail)
			{
				Array.Copy(array, newArray, Count);
			}
			else //head보다 tail이 뒤에 있는 경우 
			{
				Array.Copy(array, head, newArray, 0, array.Length - head);
				Array.Copy(array, 0, newArray, array.Length - head, tail);

				head = 0;
				tail = Count;
			}
			array = newArray;

			
		}

		/// <summary>
		/// 큐에서 데이터 출력
		/// </summary>
		/// <returns></returns>
		public T Dequeue()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			T result = array[head];
			MoveNext(ref head);
			return result;
		}

		private void MoveNext(ref int index)
		{
			index = (index == array.Length - 1) ? 0 : index + 1;
		}

		
	}
}
