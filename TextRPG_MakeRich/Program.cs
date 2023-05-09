using TextRPG_MakeRich.Map;

namespace TextRPG_MakeRich
{
    internal class Program
	{

		/*
		 *
		 *백만장자

-> 몬스터를 사냥해서 고기를 비축 -> 영업시작 -> 고기를 판매 -> 돈을 벌어 
-> 아이템을 사 -> 고기를 비축해 -> 고기를 팔아!

자동 사냥 -> 랜덤으로 뽑는 것. 성공 or 실패 운에 맞기기 

		1. 던전에 몬스터가 랜덤으로 생성되어야 해
		2. 몬슽

		공격은 물바울로 해!
		기본 거리는 3 > 포션을 먹으면 최대 6까지 늘릴 수는 있으나 1회용이고, 돈주고 사야해
		돈은 고기를 팔아서 얻겠징@!!!

		영원한 건 절대 없어!!

		 */
		static void Main(string[] args)
		{
			MakeRich mkRich = new MakeRich();
			mkRich.PlayGame();
		}

		
	}
}