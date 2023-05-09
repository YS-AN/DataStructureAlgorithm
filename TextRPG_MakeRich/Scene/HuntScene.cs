using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_MakeRich.Map;

namespace TextRPG_MakeRich
{
	/// <summary>
	/// 몬스터 사냥
	/// </summary>
	public class HuntScene : Scene
	{
		int moveCnt = 0;

		MapLevel level;
		int mapWidth = 0;
		int mapHeight = 0;

		bool _isRunning;

		List<Monster> monsters = new List<Monster>();

		public HuntScene(MapLevel level = MapLevel.Easy)
		{
			this.level = level;

			if(level == MapLevel.Easy)
			{
				mapHeight = 30;
				mapWidth = 30;
			}
			else
			{
				mapHeight = 25;
				mapWidth = 25;
			}
		}

		public override void StartScene()
		{
			InitScene();
			
			while(_isRunning)
			{
				Render();

				Update();
			}
			Close();
		}

		public override void InitScene()
		{
			GameMap gameMap = new GameMap();

			GameData.Map.CreatedMap(mapWidth, mapHeight, level);

			monsters.Add(Slime.CreatedSlime(1, ConsoleColor.DarkGreen));
			monsters.Add(Slime.CreatedSlime(2, ConsoleColor.DarkGreen));
			monsters.Add(Slime.CreatedSlime(3, ConsoleColor.DarkGreen));

			_isRunning = true;
		}

		public override void Render()
		{
			Console.Clear();

			GameData.Map.PrintMap();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(0, GameData.Map.MapHeight + 1);
            Console.WriteLine("\n\n게임 종료 : [ESC]");
            Console.WriteLine("[공격] Q : ↑ / A : ← / S : ↓ / D : →");
        }

		public override void Update()
		{
			moveCnt++;

			var input = Console.ReadKey();
			int move = (int)input.Key;

			if (input.Key == ConsoleKey.Escape)
			{
				_isRunning = false;
				return;
			}
			else if(move >= 37 && move <= 40)
			{
				UpdateMove(move);
			}
			else
			{
				GameData.player.Attack(input.Key);
			}

			UpdateAttack();

			UpdateBubble();

		}

		private void UpdateBubble()
		{
			List<int> rmBubbles = new List<int>();
			for (int i = 0; i < GameData.player.Bubbles.Count; i++)
			{
				if (GameData.player.Bubbles[i].MoveAction() == false)
				{
					rmBubbles.Add(i);
				}
			}
			foreach (var index in rmBubbles)
			{
				GameData.player.Bubbles.RemoveAt(index);
			}

		}

		private void UpdateMove(int move)
		{
			GameData.player.MoveAction((Direction)move - 37);

			int max = monsters.Max(x => x.Id) + 1;
			if (moveCnt % 50 == 0)
			{
				monsters.Add(Dragon.CreatedDragon(max, ConsoleColor.Red));
			}
			else if (moveCnt % 30 == 0)
			{
				monsters.Add(Slime.CreatedSlime(max, ConsoleColor.DarkGreen));
			}
		}

		private void UpdateAttack()
		{
			foreach (var monster in monsters)
			{
				monster.MoveAction();

				if (GameData.Map.map[monster.CurrentPos.y, monster.CurrentPos.x] == MapItem.Bubble)
				{
					monster.Die();
					monsters.Remove(monster);

					//todo. 사냥에 성공에 대한 보상
				}

				//몬스터에게 잡히면 게임 종료
				if (monster.CurrentPos.x == GameData.player.CurrentPos.x
						&& monster.CurrentPos.x == GameData.player.CurrentPos.y)
				{
					_isRunning = false;

					PrintEndOfHunt();
				}
			}
		}

		

		private void PrintEndOfHunt()
		{
			Console.Clear();

			List<string> msg = new List<string>();
		
			msg.Add("#######  #     #  #####             ###    #######         #     #  #     #  #     #  ####### ");
			msg.Add("#        ##    #  #    #           #   #   #               #     #  #     #  ##    #     #    ");
			msg.Add("#        # #   #  #     #         #     #  #               #     #  #     #  # #   #     #    ");
			msg.Add("#####    #  #  #  #     #         #     #  #####           #######  #     #  #  #  #     #    ");
			msg.Add("#        #   # #  #     #         #     #  #               #     #  #     #  #   # #     #    ");
			msg.Add("#        #    ##  #    #           #   #   #               #     #  #     #  #    ##     #    ");
			msg.Add("#######  #     #  #####             ###    #               #     #   #####   #     #     #    ");
			

			foreach (string data in msg)
			{
				Console.WriteLine(data);
				Thread.Sleep(500);
			}
			Console.WriteLine();
		}

		public override void Close()
		{
			MainMenuScene menu = new MainMenuScene();
			menu.StartScene();
		}
	}
}
