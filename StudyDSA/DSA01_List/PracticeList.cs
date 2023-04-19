using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DSA01_List.Practice
{
	/// <summary>
	/// 선형 리스트 구현
	/// </summary>
	internal class PracticeList
	{
		public void Practice()
		{
			DSA01_List.Practice.List<string> list = new DSA01_List.Practice.List<string>();

            Console.WriteLine($"list.Count : {list.Count}");
			Console.WriteLine($"list.Capacity : {list.Capacity}");

			for (int i=0; i<10; i++) { list.Add($"{i} 데이터!!"); }
			PrintList(list);

			Console.WriteLine($"list.Count : {list.Count}");
			Console.WriteLine($"list.Capacity : {list.Capacity}");

			list.Remove("5 데이터!!");
			list.Remove("58 데이터!!");
			list.Remove("7 데이터!!");
			try
			{
				list.RemoveAt(50);
			}
			catch (IndexOutOfRangeException ex)
			{
                Console.WriteLine("인덱스 범위 벗어남!");
                Console.WriteLine(ex.Message);
            }
			PrintList(list);

			Console.WriteLine($"list.Count : {list.Count}");
			Console.WriteLine($"list.Capacity : {list.Capacity}");

			var tmpList = new DSA01_List.Practice.List<string>();
			tmpList.Add("NEW DATA 111");
			tmpList.Add("NEW DATA 222");
			tmpList.Add("NEW DATA 333");
			tmpList.Add("NEW DATA 444");
			tmpList.Add("NEW DATA 555");
			tmpList.Add("NEW DATA 666");
			tmpList.Add("NEW DATA 777");
			list.AddRange(tmpList);
			PrintList(list);

			list.RemoveAll(x => x.Contains("!!"));
			Console.WriteLine($"list.Count : {list.Count}");
			Console.WriteLine($"list.Capacity : {list.Capacity}");
			PrintList(list);

			Console.WriteLine($"list[3] : {list[3]}");
			list.Insert(3, "NEW DATA 888");
			Console.WriteLine($"list[3] : {list[3]}");

			Console.WriteLine($"IndexOf(NEW DATA 666) : {list.IndexOf("NEW DATA 666")}");
			Console.WriteLine($"IndexOf(NEW DATA 666) : {list.IndexOf("NEW DATA 666", 1, 4)}");

			tmpList.Add("NEW DATA 777");
			tmpList.Add("NEW DATA 777");
			tmpList.Add("NEW DATA 777");
			tmpList.Add("NEW DATA 777");

			Console.WriteLine($"Find : {tmpList.Find(x => x.Substring(0, 3) == "NEW")}");
			Console.WriteLine($"FindLast : {tmpList.FindLast(x => x.Substring(0, 3) == "NEW")}");

			list.Clear();
			PrintList(list);
		}

		private void PrintList(DSA01_List.Practice.List<string> list)
		{
            Console.WriteLine("\n===========[[데이터 출력!]]===========");
            for (int i = 0; i < list.Count; i++) 
			{
				Console.WriteLine(list[i]);
            }
            Console.WriteLine("=================================\n");
        }
		
	}

	public class List<T> : IEnumerable<T>
	{
		/// <summary>
		/// 배열 초기 사이즈
		/// </summary>
		private const int InitCapacity = 3;

		/// <summary>
		/// 현재 배열 데이터 개수
		/// </summary>
		private int _size;

		/// <summary>
		/// 배열
		/// </summary>
		private T[] _items;

		public List()
		{
			_size = 0;
			_items = new T[InitCapacity];
		}

		public T this[int index]
		{
			get { CheckedIndexRange(index); return _items[index]; }
			set { CheckedIndexRange(index); _items[index] = value; }
		}


		public int Count { get { return _size; } }

		public int Capacity { get { return _items.Length; } }

		/// <summary>
		/// 데이터 추가
		/// </summary>
		/// <param name="item"></param>
		public void Add(T item)
		{
			if(_items.Length == _size)
			{
				ExtensionArray();
			}
			_items[_size++] = item;
		}

		/// <summary>
		/// 데이터 추가 (여러개 데이터)
		/// </summary>
		/// <param name="collection"></param>
		public void AddRange(System.Collections.Generic.IEnumerable<T> collection)
		{
			while(_size + collection.Count() > _items.Length)
			{
				ExtensionArray();
			}

			foreach(var item in collection)
			{
				_items[_size++] = item;
			}
		}

		/// <summary>
		/// 배열 확장
		/// </summary>
		private void ExtensionArray()
		{
            T[] newArray = new T[_items.Length * 2];
			Array.Copy(_items, newArray, _size);

			_items = newArray;

			Console.WriteLine($"\t>>>배열 길이 확장!! 현재 배열 크기 : {newArray.Length}");
		}

		/// <summary>
		/// 특정 위치에 추가
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void Insert(int index, T item)
		{
			if (_items.Length == _size)
			{
				ExtensionArray();
			}

			if(index + 1 == _size)
			{
				_items[_size++] = item;
			}

			int max = _size - index;
			T[] tmpArr = new T[max];
			Array.Copy(_items, index, tmpArr, 0, max);

			_items[index++] = item;
			_size++;

			int j = 0;
			for(int i=0; i<max; i++)
			{
				_items[index + i] = tmpArr[i];
			}
		}

		public int IndexOf(T item)
		{
			if(item == null)
				throw new ArgumentNullException("item");

			for(int i=0; i<_items.Length; i++)
			{
				if (item.Equals(_items[i]))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOf(T item, int index, int count)
		{
			if (item == null)
				throw new ArgumentNullException("item");
			if (count >= _size)
				throw new ArgumentOutOfRangeException("count");

			for (int i = index; i < count; i++)
			{
				if (item.Equals(_items[i]))
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// 데이터 제거
		/// </summary>
		/// <param name="item"></param>
		public bool Remove(T item) 
		{
			int index = IndexOf(item); 

			if(index >= 0)
			{
				_size--;
				RemoveAt(index);
				return true;
			}
			return false;
		}

		/// <summary>
		/// 인덱스로 데이터 제거
		/// </summary>
		/// <param name="index"></param>
		public void RemoveAt(int index)
		{
			CheckedIndexRange(index);

			for (int i = index; i < _items.Length - 1;)
			{
				_items[i] = _items[++i];
			}
		}

		/// <summary>
		/// 조건에 맞는 데이터 모두 삭제
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		public int RemoveAll(Predicate<T> match)
		{
			int delCnt = 0;

			/* [CHK]
			 * 반복되는 코드를 줄이는게 좋다고 들었는데... 
			 * 아래처럼(GetMatchData 메소드 이용) 줄이는 게 좋을까요?
			 * 반복되는 데이터는 줄어들지만 반복문은 2번 수행해야해서 비효율적인 것 같아서요.
			 * 
			 * => 공유할 소스면 나눠서 가독성을 높여주는 게 좋고, 혼자 쓸거면 효율을 높이기 위해 그냥 한번에 하는 게 좋음
			 *    아래와 같은 경우는 혼자 쓰는 거 + 합치면 for문 한번에 해결이 가능 = 합치는 게 더 좋음 
			 */
			T[] delArr = GetMatchData(match, out delCnt);

			if(delCnt > 0)
			{
				for(int i=0; i<delCnt; i++)
				{
					Remove(delArr[i]);
				}
			}
			
			return delCnt;
		}

		/// <summary>
		/// 모든 요소 제거
		/// </summary>
		public void Clear()
		{
			T[] newArr = new T[InitCapacity];
			_items = newArr;

			_size = 0;
		}

		/// <summary>
		/// 조건에 맞는 데이터 반환
		/// </summary>
		/// <param name="match">조건</param>
		/// <param name="size">조건에 맞는 데이터 개수</param>
		/// <returns></returns>
		private T[] GetMatchData(Predicate<T> match, out int size)
		{
			size = 0;
			T[] matches = new T[_items.Length];

			for (int i = 0; i < _size; i++)
			{
				if (match(_items[i]))
				{
					matches[size++] = _items[i];
				}
			}
			return matches;
		}

		/// <summary>
		/// 데이터 찾기. 없으면 자료형의 기본값 반환
		/// </summary>
		/// <param name="match">조건</param>
		/// <returns></returns>
		public T? Find(Predicate<T> match)
		{
			int index = FindIndex(match);
			return index < 0 ? default(T?) : _items[index];
		}

		/// <summary>
		/// 조건에 맞는 인덱스 반환
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		public int FindIndex(Predicate<T> match)
		{
			for(int i=0; i< _items.Length; i++)
			{
				if (match(_items[i]))
				{
					return i;
				}
			}
			return -1;
		}
		
		/// <summary>
		/// 주어진 배열에서 인덱스 검색
		/// </summary>
		/// <param name="match"></param>
		/// <param name="array"></param>
		/// <returns></returns>
		private int FindIndex(Predicate<T> match, T[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (match(array[i]))
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// 조건에 맞는 첫번째 데이터 반환
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		public T? FindFirst(Predicate<T> match)
		{
			return Find(match);
		}

		/// <summary>
		/// 조건에 맞는 가장 마지막 데이터를 반환
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		public T? FindLast(Predicate<T> match)
		{
			T[] reverseArr = new T[_size];

			int index = 0;
			for (int i=_size-1; i >= 0; i--)
			{
				reverseArr[index++] = _items[i];
			}

			int findIndex = FindIndex(match, reverseArr);
			return index < 0 ? default(T?) : reverseArr[findIndex];
		}

		public T[] FindAll(Predicate<T> match)
		{
			int copyCnt = 0;
			T[] tmpArr = GetMatchData(match, out copyCnt);

			T[] findArr = new T[copyCnt];

			Array.Copy(tmpArr, findArr, copyCnt);

			return findArr;
		}

		/// <summary>
		/// 인덱스 범위 벗어나면 예외처리
		/// </summary>
		/// <param name="index"></param>
		/// <exception cref="IndexOutOfRangeException"></exception>
		private void CheckedIndexRange(int index)
		{
			if (index < 0 || index >= _size)
			{
				throw new IndexOutOfRangeException();
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _size; i++)
			{
				yield return _items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for(int i=0; i< _size; i++) 
			{
				yield return _items[i];
			}
		}
	}
}
