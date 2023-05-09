using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich
{
	internal class MainMenuScene : Scene
	{
		int _cursorPosition = 0;
		int _nowPosition = 0;
		string[] _menus;

		bool _isRunning;

		public event Action OnCloseScene;

		public override void StartScene()
		{
			InitScene();

			while (_isRunning)
			{
				var input = Console.ReadKey();
				int inputKey = (int)input.Key;
				if(inputKey == 38 || inputKey == 40)
				{
					_cursorPosition += inputKey == 38 ? -1 : 1;

					Render();
				}
				else if(input.Key == ConsoleKey.Enter)
				{
					Update();
				}
			}
		}



		public override void InitScene()
		{
			_isRunning = true;

			_menus = new string[4]
			{
				"[1]. 곳간확인",
				"[2]. 영업하기",
				"[3]. 사냥하기",
				"[4]. 게임종료"
			};
			_cursorPosition = 0;

			Render();
		}

		public override void Render()
		{
			PrintIntro();

			if (_cursorPosition < 0) _cursorPosition = _menus.Length - 1;
			else if (_cursorPosition == _menus.Length) _cursorPosition = 0;

			for (int i=0; i< _menus.Length; i++)
			{
				if (_cursorPosition == i)
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine($"  > {_menus[i]}");
					continue;
				}
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"    {_menus[i]}");
			}
		}

		
		public override void Update()
		{
			switch(_cursorPosition)
			{
				case 0:
					break;
				case 1:
					break;
				case 2:
					HuntScene huntScene = new HuntScene();
					huntScene.StartScene();
					//OnCloseScene += huntScene.Close;
					break;
				case 3:
					_isRunning = false;
					Close();
					break;

			}
		}

		public override void Close()
		{
			Console.Clear();

			List<string> msg_GameOver = new List<string>();
			msg_GameOver.Add("  ###     #    #   #  #####       ###   #   #  #####  ####  ");
			msg_GameOver.Add(" #       # #   ## ##  #          #   #  #   #  #      #   # ");
			msg_GameOver.Add(" # ###  #####  # # #  #####      #   #  #   #  #####  ####  ");
			msg_GameOver.Add(" #   #  #   #  #   #  #          #   #   # #   #      #  #  ");
			msg_GameOver.Add("  ###   #   #  #   #  #####       ###     #    #####  #   # ");

			foreach (string msg in msg_GameOver)
			{
				Console.WriteLine(msg);
				Thread.Sleep(500);
			}
			Console.WriteLine();
		}

		private void PrintIntro()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("");
			Console.WriteLine(" --------------------------------------------");
			Console.WriteLine("|                  (가제)                    |");
			Console.WriteLine(" --------------------------------------------");
			Console.WriteLine();
		}
	}
}
