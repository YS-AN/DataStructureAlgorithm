using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA04_Stack
{
	public class Stack<T>
	{
		private const int InitCapacity = 4; //초기 스택 크기

		/// <summary>
		/// 스택 현재 위치를 가리킴
		/// </summary>
		private int top;

		/// <summary>
		/// 스택에 들어간 데이터
		/// </summary>
		private T[] array;

		/// <summary>
		/// 데이터 개수 반환 
		/// (LIFO > 현위치 = 데이터 개수 / 배열은 ZERO BASE, +1을 해줘야 해)
		/// </summary>
		public int Count { get { return top + 1; } }

		public Stack()
		{
			array = new T[InitCapacity];
			top = -1;
		}

		/// <summary>
		/// 최상단 데이터 반환
		/// </summary>
		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[top];
		}

		/// <summary>
		/// 데이터 삽입
		/// </summary>
		/// <param name="item"></param>
		public void Push(T item)
		{
			if (IsFull())
			{
				Grow();
			}
			array[++top] = item;
		}

		/// <summary>
		/// 데이터 꺼내기
		/// </summary>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public T Pop()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[top--];
		}

		/// <summary>
		/// 스택이 비어 있는지 확인
		/// </summary>
		/// <returns></returns>
		private bool IsEmpty()
		{
			//count가 index+1이니까 0이면 index는 -1임 > 데이터 없는 상태라는 뜻
			return Count == 0;
		}

		/// <summary>
		/// 스택이 꽉 찼는지 확인
		/// </summary>
		/// <returns></returns>
		private bool IsFull()
		{
			return Count == array.Length; //개수와 배열의 길이가 같다? 스택이 꽉 참
		}

		/// <summary>
		/// 스택 정리
		/// </summary>
		public void Clear()
		{
			array = new T[InitCapacity];
			top = -1;
		}

		/// <summary>
		/// 스택 사이즈 늘리기
		/// </summary>
		private void Grow()
		{
			int newCapacity = array.Length * 2;
			T[] newArray = new T[newCapacity];
			Array.Copy(array, 0, newArray, 0, Count);
			array = newArray;
		}
	}
}