using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
	internal class MapData
	{
		public static Player player; //싱글톤 -> 게임 전체에서 플레이어는 무조건 하나니까 static로 선언함
		public static List<Monster> monsters;

		public static bool[,] map;

		public static void Init()
		{
			player = new Player();
			monsters = new List<Monster>();
		}

		public static void Release()
		{

		}

		public static void LoadLevel1()
		{
			//todo.절차지향 맵 생성을 활용해서 맵을 랜덤으로 가져오도록 함
			map = new bool[,]
			{
				{ false, false, false, false, false, false, false, false, false, false, false, false, false, false },
				{ false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
				{ false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
				{ false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
				{ false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
				{ false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
				{ false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false, false, false, false, false, false, false, false, false, false, false, false, false, false },
			};

			player.position = new Position(2, 2); //플레이어 시작 위치 지정

			Monster slime1 = new Slime();
			slime1.position = new Position(3, 5);
			monsters.Add(slime1 );

			Monster slime2 = new Slime();
			slime2.position = new Position(7, 5);
			monsters.Add(slime2);

			Monster dragon = new Dragon();
			dragon.position = new Position(12, 12);
			monsters.Add(dragon);
		}

		public static Monster MonsterInPosition(Position position)
		{
			return monsters.Find(f => f.position.x == position.x && f.position.y == position.y);
		}
	}
}