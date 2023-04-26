using System.Diagnostics.CodeAnalysis;

namespace DSA08_HashTable
{
	internal class Program
	{
		static void Main(string[] args)
		{
			OpenAddressing();
		}

		/// <summary>
		/// 해시충돌 시 해결방법 : 개방 주소법
		/// </summary>
		static void OpenAddressing()
		{
            Console.WriteLine("\n\n[선형탐색]");
			DSA08_HashTable.UserDefinition.Dictionary<int, int> LinearDic = new UserDefinition.Dictionary<int, int>(UserDefinition.Dictionary<int, int>.ProbingType.Linear);
			AddDictionary(LinearDic);
			LinearDic.PrintDictionaryKey();

			Console.WriteLine("\n\n[제곱탐색]");
			DSA08_HashTable.UserDefinition.Dictionary<int, int> QuadraticDic = new UserDefinition.Dictionary<int, int>(UserDefinition.Dictionary<int, int>.ProbingType.Quadratic);
			AddDictionary(QuadraticDic);
			QuadraticDic.PrintDictionaryKey();

			Console.WriteLine("\n\n[이중해시]");
			DSA08_HashTable.UserDefinition.Dictionary<int, int> DoubleDic = new UserDefinition.Dictionary<int, int>(UserDefinition.Dictionary<int, int>.ProbingType.DoubleHash);
			AddDictionary(DoubleDic);
			DoubleDic.PrintDictionaryKey();
		}

		static void AddDictionary(DSA08_HashTable.UserDefinition.Dictionary<int, int> dic)
		{
			for (int i = 0; i < 5;) dic.TestAdd(1, ++i);
			for (int i = 0; i < 5;) dic.TestAdd(2, ++i);

			dic.TestAdd(1, 6);
			dic.TestAdd(1, 7);
			dic.TestAdd(1, 8);

			dic.TestAdd(2, 6);
			dic.TestAdd(2, 7);
		}
	}
}