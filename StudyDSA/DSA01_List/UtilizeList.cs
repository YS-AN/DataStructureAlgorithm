using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSA01_List
{
	/// <summary>
	/// 리스트의 활용
	/// </summary>
	internal class UtilizeList
	{
		public void DoUtilizeList()
		{
			DSA01_List.List<string> list = new DSA01_List.List<string>();
			list.Add("0번 데이터");
			list.Add("1번 데이터");
			list.Add("2번 데이터");
			list.Add("3번 데이터");
			list.Add("4번 데이터");
			list.Add("5번 데이터");
			list.PrintList();

			list.Remove("3번 데이터");
			list.Remove("6번 데이터");
			list.PrintList();

			//list.RemoveAt(6); //예외처리 > 프로그램 종료
			Console.WriteLine();

			//인덱스로 접근
			Console.WriteLine($"list[2] : {list[2]}");
			list[0] = "데이터 변경";
			Console.WriteLine($"list[0] : {list[0]}");
			Console.WriteLine();

			Console.WriteLine($"[Find] {list.Find(x => x == "3번 데이터")}");
			Console.WriteLine($"[Find] {list.Find(x => x == "4번 데이터")}");

			Console.WriteLine($"[FindIndex] {list.FindIndex(x => x == "3번 데이터")}");
			Console.WriteLine($"[FindIndex] {list.FindIndex(x => x == "4번 데이터")}");
			Console.WriteLine();
		} 
	}

	/// <summary>
	/// 실제 리스트 내부를 구현해보기
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class List<T>
	{
		private const int DefaultCapacity = 4;

		private T[] items;
		private int size;

		public List()
		{
			this.items = new T[DefaultCapacity];
			this.size = 0;
		}

		//인덱서 구현
		public T this[int index]
		{
			get
			{
				CheckedIndexRange(index);
				return items[index];
			}
			set
			{
				CheckedIndexRange(index);
				items[index] = value;
			}
		}

		//Count할 때 size를 반환하는 이유
		//삭제를 할 경우, Length = 10이지만 size는 9임. items[9]는 무의미한 데이터로 취급하기 때문
		public int Count { get { return size; } }

		//Capacity는 배열의 길이로 반환하는 이유,
		//삭제를 한 경우 size는 9지만, 총 쓸 수 있는 배열의 크기가 변하는 건 아니기 때문에 총 크기는 배열의 길이로 반환함
		public int Capacity { get { return items.Length; } }


		public void Add(T item)
		{
			if (size >= items.Length)
			{
				Grow(); 
			}
			items[size++] = item;

            Console.WriteLine($"[ADD] {item}");
        }
	
		public bool Remove(T item)
		{
			int index = IndexOf(item);

			if(index >= 0)
			{
				RemoveAt(index);
				return true;
			}
			return false;
		}

		public int IndexOf(T item)
		{
			return Array.IndexOf(items, item, 0, size);
		}

		public void RemoveAt(int index) 
		{
			CheckedIndexRange(index);

			/*
			for(int i=index; i<items.Length-1; )
			{
				items[i] = items[++i];
			}
			*/
			size--;
			Array.Copy(items, index + 1, items, index, size - index); 
			//items[index+1]부터 복사 시작해서 items[index]부터 저장함 > (size-index)만큼 반복함.  
			//size-index = 삭제된 데이터 바로 뒤부터 끝까지의 개수
			//마지막 데이터가 남아 있으나 ADD하면 바로 덮어쓸 것이기 때문에 그냥 둠. (유효하지 않은 데이터)
		}

		//데이터 못 찾는 경우 반환 값이 null이 되어야 해서 nullable로 선언
		public T? Find(Predicate<T> match)
		{
			if (match == null) 
				throw new ArgumentNullException("match");

			//선형적 탐색
			for(int i = 0; i < size; i++) 
			{
				if (match(items[i]))
				{
					return items[i];
				}
			}
			return default(T); //default(T) 각 자료형의 기본 값을 반환
		}

		public int FindIndex(Predicate<T> match)
		{
			if (match == null)
				throw new ArgumentNullException("match");

			for (int i = 0; i < size; i++)
			{
				if (match(items[i]))
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// 내부적으로 List 사이즈를 키우는 방법
		/// </summary>
		private void Grow()
		{
            Console.WriteLine("=====[GROW LISt]=====");

            int newCapacity = items.Length * 2;
			T[] newItems = new T[newCapacity]; //원래 있던 items보다 더 큰 사이즈의 배열을 만듦
	
			//원래 있던 items 데이터를 새로운 배열로 복사함.
			Array.Copy(items, 0, newItems, 0, size); 
	
			items = newItems; 
			//items의 주소를 newItems의 주소로 변경함.
			//기존의 items는 아무도 참조하는 곳이 없기 때문에 GC에서 삭제함
		}

		/// <summary>
		/// 인덱스 범위 벗어나면 예외처리
		/// </summary>
		/// <param name="index"></param>
		/// <exception cref="IndexOutOfRangeException"></exception>
		private void CheckedIndexRange(int index)
		{
			if (index < 0 || index >= size)
			{
				throw new IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// 배열 내용 전체 확인 (단순 확인 용)
		/// </summary>
		public void PrintList()
		{
			Console.WriteLine("\n====[데이터 전체 출력]====");
			for (int i=0; i < size; i++) 
			{
				Console.WriteLine(items[i]);
            }
			Console.WriteLine("===================\n");
		}
	}
}
