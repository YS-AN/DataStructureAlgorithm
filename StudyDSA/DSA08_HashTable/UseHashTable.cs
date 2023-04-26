using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA08_HashTable
{
	internal class UseHashTable
	{
		public void HashTable_Dic()
		{
			Dictionary<string, Item> dic = new Dictionary<string, Item>();
			dic.Add("초기 아이템", new Item("초보자용 검", 10));
			dic.Add("초기 방어구", new Item("초보자용 가죽갑옷", 30));
			dic.Add("전직 아이템", new Item("푸른결정", 1));

			if(dic.ContainsKey("초기 아이템"))
			{
				dic.Remove("초기 아이템");
			}
		}
	}

	public class Item
	{
		public string name;
		public int weight;

		public Item(string name, int weight)
		{
			this.name = name;
			this.weight = weight;
		}

	}
}
