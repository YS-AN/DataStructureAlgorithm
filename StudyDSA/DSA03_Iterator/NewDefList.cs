using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA03_Iterator
{
	/// <summary>
	/// DSA01에서 만들었던 List에 반복기 기능 추가
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal class List<T> : DSA01_List.List<T>, IEnumerable<T>
	{
		/// <summary>
		/// IEnumerable<T>의 인터페이스 메소드
		/// > 반복기를 꺼내주는 메소드임
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		/// <summary>
		/// IEnumerable의 인터페이스 메소드 
		/// </summary>
		/// <returns></returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		/// <summary>
		/// 반복기 
		///	-> 각 자료구조의 반복기는 자료구조에 맞는 반복기가 필요하기 때문에 각 자료구조별로 구분하기 위해 클래스 내부에 만듦
		///	   (클래스 밖에 쓰렬면 자료구조별로 반복기이름을 만들어 줘야함...)
		/// </summary>
		public struct Enumerator : IEnumerator<T>
		{
			/// <summary>
			/// 현재 가리키고 있는 인덱스
			/// </summary>
			private int index;

			/// <summary>
			/// 현재 가지고 있는 리시트
			/// </summary>
			private List<T> list;

			/// <summary>
			/// 현재 값을 담고 있는 변수
			/// </summary>
			private T _current;
			public T Current { get { return _current; } }

			public Enumerator(List<T> list)
			{
				this.index = -1; //처음 시작했을 때 +1하고 시작하니까 0번을 볼 수 없음. 미리하나 +1하는 걸 예상하고 초기화 해 줌
				this.list = list;
				_current = default(T);
			}

			object IEnumerator.Current
			{
				get
				{
					if (index < 0 || index >= list.Count)
						throw new InvalidOperationException();
					return list[index];
				}
			}

			/// <summary>
			/// 반복이 끝났을 때 호출되는 함수
			/// </summary>
			public void Dispose() 
			{
                Console.WriteLine("Dispose 호출");
            }

			/// <summary>
			/// 다음으로 이동
			/// </summary>
			/// <returns>리스트의 가장 끝이면 false 반환</returns>
			public bool MoveNext()
			{
				if (index + 1 == list.Count) //현재 인덱스가 리스트의 마지막을 가리키고 있는가?
				{
					_current = default(T);
					return false;
				}
				else
				{
					_current = list[++index];
					return true;
				}
			}

			/// <summary>
			/// 처음으로 이동
			/// </summary>
			public void Reset()
			{
				index = 0;
			}
		}
	}
}