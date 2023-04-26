using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSA08_HashTable.UserDefinition
{
	//todo.IEqualityComparer 주석 해제하기!  
	//기본 자료형으로 테스트 하기 위해 잠깐 주석 달아 둔 것.(IEqualityComparer 있으면 기본 자료형으로 테스트가 안 됨)

	/// <summary>
	/// Dictionary 내부 구현
	/// </summary>
	/// <typeparam name="TKey">키</typeparam>
	/// <typeparam name="TValue">값</typeparam>
	internal class Dictionary<TKey, TValue> //where TKey : IEqualityComparer<TKey> 
	{
		/// <summary>
		/// 배열의 초기 값 (처음부터 크기를 크게 잡음)
		/// </summary>
		private const int InitCapacity = 1000;

		/// <summary>
		/// 이중 해싱에서 사용할 나눗셈법 기준 값
		/// </summary>
		private const int DoubleHashRefVal = 11;

		private ProbingType probingType;

		/// <summary>
		/// Dictionary 인덱스 탐사 방법
		/// </summary>
		public enum ProbingType { Linear, Quadratic, DoubleHash }

		private struct Entry
		{
			public enum State { None, Using, Deleted }

			public State state;
			public int hashCode;
			public TKey key;
			public TValue value;
		}

		private Entry[] table;

		public TValue this[TKey key]
		{
			get
			{
				int index = GetHashIndex(key);
				int num = 1;

				while (table[index].state == Entry.State.Using)
				{
					if (key.Equals(table[index].key))
					{
						return table[index].value;
					}

					//찾아서 가는 데 갑자기 빈공간이 나온다? 잘못 만난 것. 
					if (table[index].state == Entry.State.None)
					{
						break; 
					}

					index = IndexProbing(index, num++, key);
				}

				throw new InvalidOperationException(); //못찾으면 오류 반환
			}
			set
			{
				int index = GetHashIndex(key);
				int num = 1;

				while (table[index].state == Entry.State.Using)
				{
					if (key.Equals(table[index].key))
					{
						table[index].value = value;
						return;
					}

					//찾아서 가는 데 갑자기 빈공간이 나온다? 잘못 만난 것. 
					if (table[index].state != Entry.State.None)
					{
						break;
					}

					index = IndexProbing(index, num++, key);
				}

				throw new InvalidOperationException();
			}
		}

		public Dictionary()
		{
			table = new Entry[InitCapacity];
			probingType = ProbingType.Linear;
		}

		public Dictionary(ProbingType probingType) : this()
		{
			this.probingType = probingType;
		}

		/// <summary>
		/// 데이터 저장
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Add(TKey key, TValue value)
		{
			int index = GetHashIndex(key);
			int num = 1;

			//index 위치가 사용 중이면, 저장 할 수 없음. 다음 방으로 이동해야 함 (인덱스 충돌 상황)
			while (table[index].state == Entry.State.Using) 
			{
				if (key.Equals(table[index].key)) //키는 유니크한 값이어여 하니까, 현재 키 값이 이미 있는 값이면?
				{
					throw new ArgumentException(); //키 값 중복으로 예외 처리함
				}
				index = IndexProbing(index, num++, key); //빈 위치가 나올 때까지 반복해서 이동함
			}

			//빈 자리가 나온 경우 그 자리에 값을 추가함.
			table[index] = AddEntry(key, value, index);
		}

		/// <summary>
		/// 데이터 저장 
		/// > 키 충돌 확인을 위한 메소드 > 키 중복 허용함
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void TestAdd(TKey key, TValue value)
		{
			int index = GetHashIndex(key);
			int num = 1;

			//index 위치가 사용 중이면, 저장 할 수 없음. 다음 방으로 이동해야 함 (인덱스 충돌 상황)
			while (table[index].state == Entry.State.Using)
			{
				index = IndexProbing(index, num++, key); //빈 위치가 나올 때까지 반복해서 이동함
			}

			//빈 자리가 나온 경우 그 자리에 값을 추가함.
			table[index] = AddEntry(key, value, index);
		}

		private Entry AddEntry(TKey key, TValue value, int index)
		{
			Entry entry = new Entry();
			entry.key = key;
			entry.value = value;
			entry.state = Entry.State.Using;
			entry.hashCode = key.GetHashCode();

			return entry;
		}

		/// <summary>
		/// 삭제
		/// </summary>
		/// <param name="key">키 값</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public void Remove(TKey key, TValue val)
		{
			int index = GetHashIndex(key);
			int num = 1;
			int maxIndex = index + table.Length - 1;
			int round = 0;

			//현재 값이 빈 공간이 나온다? 그럼 모든 연결이 끝난 상태를 의미함
			//빈 공간이 아닌 상태까지만 반복하도록 함
			while (table[index].state != Entry.State.None) 
			{
				if (key.Equals(table[index].key) && val.Equals(table[index].value))
				{
					table[index].state = Entry.State.Deleted;
					return;
					//값을 그냥 지워버리면 나중에 인덱스로 검색할 때 빈공간이 나와 버리니까 무조건 빈방을 만나 오류를 반환함.
					//  ->  그 이후에 연결된 키로 넘어가서 검색을 할 수 없기 때문에 삭제가 아니라 상태값만 상태로 변경함
				}

				index = IndexProbing(index, num++, key);

			}

			throw new InvalidOperationException();
		}

		/// <summary>
		/// 키 값을 받아 해시 인덱스를 반환함
		/// </summary>
		/// <param name="key">키 값</param>
		/// <returns>해시 인덱스</returns>
		private int GetHashIndex(TKey key)
		{
			//키 값을 index의 값으로 변환 = 해싱작업
			int hashCode = key.GetHashCode();
			return Math.Abs(hashCode % table.Length); //키 값을 int형으로 변환 후 나눗셈법 활용
		}

		/// <summary>
		///  인덱스 탐사
		/// </summary>
		/// <param name="index">현재 인덱스 값</param>
		/// <param name="num">탐사 횟수</param>
		/// <param name="key">키 값</param>
		/// <returns></returns>
		private int IndexProbing(int index, int num, TKey key = default(TKey))
		{
			int move = 0;

			switch (probingType)
			{
				//선형탐색
				case ProbingType.Linear:
					move = 1; //무조건 한칸씩 뒤로 이동
					break;

				//제곱탐색
				case ProbingType.Quadratic:
					move = Convert.ToInt32(Math.Pow(num, 2));  //N의 제곱만큼 이동
					break;

				//이중해시
				case ProbingType.DoubleHash:
					move = key.GetHashCode() % DoubleHashRefVal; //새로운 해시값만큼 이동
					break;
			}

			return (index + move) % table.Length;
		}

		/// <summary>
		/// dictionary 키 값 차례대로 출력
		/// </summary>
		public void PrintDictionaryKey()
		{
			for (int i = 0; i < table.Length; i++)
			{
				if (table[i].state == Entry.State.Using)
				{
                    Console.Write($"{table[i].key}   ");
                }
			}
            Console.WriteLine();
        }
	}
}
