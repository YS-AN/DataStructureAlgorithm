using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
	internal class MainMenuScene : Scene
	{
		public MainMenuScene(Game game) : base(game) 
		{
		}

		public override void Render()
		{
			StringBuilder sbMenu = new StringBuilder();

			sbMenu.AppendLine("1. 게임 시작");
			sbMenu.AppendLine("2. 게임 종료");
			sbMenu.AppendLine().Append("메뉴를 선택하세요 : ");

            Console.Write(sbMenu.ToString());
        }

		public override void Update()
		{
			string input = Console.ReadLine();

			int command;
			if(!int.TryParse(input, out  command))
			{
				PrintWrongInput();
				return;
			}
			switch(command)
			{
				case 1:
					game.GameStart();
					break;
				case 2:
					game.GameStop();
					break;
				default: PrintWrongInput(); break;
			}
		}

		private void PrintWrongInput()
		{
			Console.WriteLine("\n잘못 입력 하셨습니다.!");
			Thread.Sleep(1000); //메시지 확인을 위해 콘솔 창을 잠깐 멈춤
		}
	}
}
