using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA01_List
{
	/// <summary>
	/// List (동적 배열)
	/// </summary>
	internal class DynamicArray
	{
		public void UseList()
		{
			//리스트 선언 : 선언시점에 크기를 정하지 않음
			System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();

			// 배열 요소 삽입
			list.Add("0번 데이터");
			list.Add("1번 데이터");
			list.Add("2번 데이터");

			// 배열 요소 삭제
			Console.WriteLine($"[삭제 전] list[1] : {list[1]}"); //output : 1번 데이터
			list.Remove("1번 데이터"); //중간 삭제 가능. > 중간 삭제하고나면 뒤에 있던게 당겨짐.
			Console.WriteLine($"[삭제 후] list[1] : {list[1]}");  //output : 2번 데이터

			// 배열 요소 접근
			list[0] = "데이터0"; //배열이니까 인덱스 접근 가능
			string value = list[0];

			// 배열 요소 탐색
			string? findValue = list.Find(x => x.Contains('2'));
			int findIndex = list.FindIndex(x => x.Contains('0'));

			Console.WriteLine($"List Count : {list.Count()}");
            //길이는 애초에 크게 잡아둠.
            //길이가 아니라 몇개를 쓰고 있는지를 확인해야 함.
            Console.WriteLine($"List Capacity : {list.Capacity}"); //리스트의 최대 사이즈 확인 

			for (int i = 3; i < 9; i++) { list.Add($"{i}번 데이터"); } //6개 더 추가함

			Console.WriteLine($"List Count : {list.Count()}");
			Console.WriteLine($"List Capacity : {list.Capacity}"); //Capacity가 늘어남
		}
	}
}
