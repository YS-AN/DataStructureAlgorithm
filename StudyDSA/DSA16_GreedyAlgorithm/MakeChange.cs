using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA16_GreedyAlgorithm
{
	internal class MakeChange
	{
		int[] coinUnits;

		public MakeChange()
		{
			coinUnits = new int[] { 500, 100, 50, 10 };
		}

		/// <summary>
		/// 거스름돈 계산
		/// </summary>
		/// <param name="price">물건 가격</param>
		/// <param name="pay">지불한 돈</param>
		public void GetChange(int price, int pay)
		{
			int changeAmount = pay - price;
			Coin[] change = new Coin[coinUnits.Length];

			for (int i = 0; i < coinUnits.Length; i++) //3.해 검사 : 큰 단위 동전부터 작은 동전 순으로 거스름돈의 개수를 셈
			{
				//1.해선택 : 현 단계에서 가장 큰 단위 동전을 선택함 = coinUnits[i]
				change[i] = CountCoins(changeAmount, coinUnits[i]); 
				changeAmount = changeAmount - (change[i].Amount * change[i].Unit);
			}

			PrintChange(change);
		}

		private Coin CountCoins(int amt, int unit)
		{
			int coinCnt = 0;
			int currentAmt = amt;

			while (currentAmt >= unit) //2.실행 가능성 검사 : 현재 남은 금액의 동전의 단위보다 큰지 확인함
			{
				coinCnt++;
				currentAmt = currentAmt - unit;
			}
			return new Coin(coinCnt, unit);
		}

		/// <summary>
		/// 거스름돈 출력
		/// </summary>
		/// <param name="changes"></param>
		private void PrintChange(Coin[] changes)
		{
			for (int i = 0; i < changes.Length; i++)
			{
				Console.WriteLine($"{changes[i].Unit}원 x {changes[i].Amount}개");
			}
		}
	}

	public class Coin
	{
		public Coin(int amt, int unit)
		{
			Amount = amt;
			Unit = unit;
		}

		/// <summary>
		/// 단위
		/// </summary>
		public int Unit;

		/// <summary>
		/// 금액
		/// </summary>
		public int Amount;
	}
}
