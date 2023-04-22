using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA04_Stack
{
	/// <summary>
	/// 리스트를 이용한 스택 구현
	/// </summary>
	internal class AdapterStack<T>
	{
		//Adapter 패턴 : 원래 있는 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환하는 것
		// > 이미 리스트에서 기능 구현을 잘 해뒀기 때문에 리스트를 이용하면 스택을 훨씩 쉽게 구현 가능함
		//		> 예외 처리? 스택에서 오류 날만한건 이미 리스트에서도 오류나기 때문에 신경 안 써도 돼!
		private List<T> container;

		public int Count { get { return container.Count; } }

		public AdapterStack()
		{
			container = new List<T>();
		}

		public void Push(T item)
		{
			container.Add(item);
		}

		public T Pop()
		{
			T item = container[container.Count - 1];
			container.RemoveAt(container.Count - 1);
			return item;
		}

		public T Peek()
		{
			return container[container.Count - 1];
		}
	}
}