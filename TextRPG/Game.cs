using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG
{
	public class Game
	{
		private bool _running;

		private enum SceneType
		{
			MainMenu,
			Map,
			Inventory,
			Battle
		}
		/// <summary>
		/// 현재 진형되고 있는 씬
		/// </summary>
		private Scene _curScene;

		private Dictionary<SceneType, Scene> sceneDic = null;


		// todo.미리 선언하지 말고 abstract 함수를 new로 상속받아서 해보기!!
		private MainMenuScene _menuScene;
		private MapScene _mapScene;
		private InventoryScene _inventoryScene;
		private BattleScene _battleScene;

		public Game()
		{
			sceneDic = new Dictionary<SceneType, Scene>();
		}

		public void Run()
		{
			//초기화
			Init();

			//게임 루프
			while (_running)
			{
				//랜더링 (text 기반은 상황을 그려주고 입력을 받는 경우가 많음. 보통은 입력 > 갱신 > 랜더링 순서로 진행됨)
				Render();
				//입력

				//업데이트
				Update();
			}

			//게임 종료 -> 마무리 작업
			MapData.Release();
		}

		
		public void Init()
		{
			_running = true;

			Console.CursorVisible = false;

			MapData.Init();

			sceneDic.Add(SceneType.MainMenu, new MainMenuScene(this));
			sceneDic.Add(SceneType.Map, new MapScene(this));
			sceneDic.Add(SceneType.Inventory, new InventoryScene(this));
			sceneDic.Add(SceneType.Battle, new BattleScene(this));

			_menuScene = new MainMenuScene(this);
			_mapScene = new MapScene(this);
			_inventoryScene = new InventoryScene(this);
			_battleScene = new BattleScene(this);

			_curScene = _menuScene;
		}

		private void Render()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;

			_curScene.Render(); //현재 씬을 랜더링 함. (현재 어떤 씬인지 중요하지 않음. -> 받은 씬의 랜더 함수를 돌려서 랜더링 함)
		}

		private void Update()
		{
			_curScene.Update(); //현재 씬을 업데이트함
		}

		public void GameStart()
		{
			MapData.LoadLevel1();
			_curScene = _mapScene; //게임의 시작 -> 맵 씬으로 시작함
		}

		public void GameStop()
		{
			Console.Clear();
			
			List<string> msg_GameOver = new List<string>();
			msg_GameOver.Add("  ###     #    #   #  #####       ###   #   #  #####  ####  ");
			msg_GameOver.Add(" #       # #   ## ##  #          #   #  #   #  #      #   # ");
			msg_GameOver.Add(" # ###  #####  # # #  #####      #   #  #   #  #####  ####  ");
			msg_GameOver.Add(" #   #  #   #  #   #  #          #   #   # #   #      #  #  ");
			msg_GameOver.Add("  ###   #   #  #   #  #####       ###     #    #####  #   # ");

			foreach(string msg in msg_GameOver)
			{
                Console.WriteLine(msg);
				Thread.Sleep(500);
            }
            Console.WriteLine();

			_running = false;
		}

		/// <summary>
		/// 배틀씬 시작
		/// </summary>
		/// <param name="monster"></param>
		public void BattleStart(Monster monster)
		{
			_curScene = _battleScene;
			_battleScene.BattleStart(monster);
		}

		public void DrawMap()
		{
			_curScene = _mapScene;
		}
	}
}
