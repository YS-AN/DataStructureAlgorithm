using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich
{
	internal class MakeRich
	{
		bool _running = false;
		
		public void PlayGame()
		{
			

			//초기화
			InitGame();

			MainMenuScene menu = new MainMenuScene();
			menu.StartScene();
		}

		private void InitGame()
		{
			Console.CursorVisible = false;

			_running = true;

			GameData.Map = new Map.GameMap();
			GameData.player = new Player();
		}

		//게임 종료 시 작업.

		
	}
}
