using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA07_BinarySearchTree
{
	internal class UseBinarySearchTree
	{
		public void BinarySearchTree()
		{
			//이진 트리 탐색은 기본적으로 정렬을 보장해줌. -> "sorted"
			SortedSet<int> sortedSet = new SortedSet<int>();
			sortedSet.Add(1);
			sortedSet.Add(2);
			sortedSet.Add(3);
			sortedSet.Add(4);
			sortedSet.Add(5);

			int searchVal;
			bool find = sortedSet.TryGetValue(3, out searchVal); //탬식 시도

			sortedSet.Remove(3);

			//key-value형태의 이진트리: SortedDictionary
			//key : 탐색용
			//value : 실제 데이터
			SortedDictionary<string, Monster> sortedDic = new SortedDictionary<string, Monster>();

			sortedDic.Add("피카츄", new Monster { name = "피카츄", hp = 100 });
			sortedDic.Add("파이리", new Monster { name = "파이리", hp = 120 });
			sortedDic.Add("꼬부기", new Monster { name = "꼬부기", hp = 80 });
			sortedDic.Add("리아코", new Monster { name = "리아코", hp = 110 });
			sortedDic.Add("이상해씨", new Monster { name = "이상해씨", hp = 130 });

			Monster charmander;
			sortedDic.TryGetValue("파이리", out charmander);
			Monster indexerMonster = sortedDic["파이리"]; //인덱서를 통한 탐색 시도 > 키 값을 인덱스로 쓸 수 있음

			sortedDic.Remove("리아코"); //키값으로 삭제 가능 

		}
	}

	internal class Monster
	{
		public string name;
		public int hp;
	}
}
