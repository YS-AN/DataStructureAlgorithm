
using System;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
	static void Main(string[] args)
	{
		int level = int.Parse(Console.ReadLine());

		string[] triangleData = new string[level];
		for (int i = 0; i < level; i++)
			triangleData[i] = Console.ReadLine();

		if (level == 1) { Console.WriteLine(level); return; }

		int half = level / 2;
		int nodeCnt = (level + 1) * half + (level % 2 == 0 ? 0 : half + 1);

		int[] items = new int[nodeCnt];
		int index = 0;
		foreach (string str in triangleData)
		{
			var arr = str.Split(" ");
			for (int i = 0; i < arr.Length; i++)
				items[index++] = Convert.ToInt32(arr[i]);
		}

		if(level == 2) { Console.WriteLine(items[0] + (items[1] > items[2] ? items[1] : items[2])); return; }

		int lSum = GetSum(items, 1, 2, level); 
		int rSum = GetSum(items, 2, 2, level);

		Console.WriteLine((lSum > rSum ? lSum : rSum) + items[0]);
	}

	private static int GetSum(int[] items, int index, int level, int last)
	{
		if (level == last)
			return items[index];

		
		int next = items[index + level] > items[index + level + 1] ? index + level : index + level + 1;
		return items[index] + GetSum(items, next, level + 1, last);
	} 
}