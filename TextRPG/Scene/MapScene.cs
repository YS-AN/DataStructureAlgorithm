using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG
{
	internal class MapScene : Scene
	{
		public MapScene(Game game) : base(game) 
		{
		}

		public override void Render()
		{
			PrintMap();
		}

		public override void Update()
		{
			ConsoleKeyInfo input = Console.ReadKey();

			int move = (int)input.Key;
			MapData.player.Move((Direction)move-37);

			//플레이어 몬스터 접근 -> 플레이어가 이동한 위치에 몬스터가 있다면? 플레이어와 몬스터가 만난 것으로 판단함 -> 전투
			Monster facedMonster = MapData.MonsterInPosition(MapData.player.position);
			if (facedMonster != null)
			{
				//전투시작
				game.BattleStart(facedMonster);
				return;
			}

			//몬스터 이동
			foreach(var monster in MapData.monsters)
			{
				monster.MoveAction();

				//몬스터가 이동했는데, 그 위치에 플레이어가 있다면? 전투시작
				if (monster.position.x == MapData.player.position.x && monster.position.y == MapData.player.position.y)
				{
					//전투시작
					game.BattleStart(monster);
					return;
				}
			}

		}

		private void PrintMap()
		{
			Console.ForegroundColor = ConsoleColor.White;

			StringBuilder sb = new StringBuilder();	

			for(int i=0; i<MapData.map.GetLength(0);i++)
			{
				for(int j=0; j<MapData.map.GetLength(1); j++)
				{
					sb.Append(MapData.map[i, j] ? '　' : '■');
				}
				sb.AppendLine();
			}
            Console.WriteLine(sb.ToString());

			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(MapData.player.position.x * 2, MapData.player.position.y);
			Console.Write(MapData.player.ICON);

			Console.ForegroundColor = ConsoleColor.Green;
			foreach(var monster in MapData.monsters)
			{
				Console.SetCursorPosition(monster.position.x * 2, monster.position.y);
				Console.Write(monster.ICON);
			}
		}
	}
}
