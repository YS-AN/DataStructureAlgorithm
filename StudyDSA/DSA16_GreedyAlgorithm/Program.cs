using System.Security.Principal;

namespace DSA16_GreedyAlgorithm
{
	/// <summary>
	/// 탐욕 알고리즘
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			int price = 0;
			int pay = 0;

            Console.Write("물건 가격을 입력하세요 : ");
			price = int.Parse(Console.ReadLine());

			Console.Write("손님이 지불한 금액을 입력하세요 : ");
			pay = int.Parse(Console.ReadLine());

			MakeChange makeChange = new MakeChange();
			makeChange.GetChange(price, pay);
		}
	}
}