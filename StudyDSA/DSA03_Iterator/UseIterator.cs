using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA03_Iterator
{
	internal class UseIterator
	{
		public void DoIterator()
		{
			//반복기 직접조작
			List<string> strings = new List<string>();
			for(int i= 0; i < 5; i++) { strings.Add($"{i}데이터"); }

			IEnumerator<string> iter = strings.GetEnumerator();
			iter.MoveNext(); //다음으로 주소로 이동.
							 //더 이상 갈 곳이 없으면 false를 반환함
							 //IEnumerator를 상속받아야 MoveNext 동작이 가능해짐
			Console.WriteLine(iter.Current); //현주소의 value
			iter.MoveNext();
			Console.WriteLine(iter.Current);

			iter.Reset(); //처음으로 이동
            Console.WriteLine(iter.Current);
        }
	}
}
