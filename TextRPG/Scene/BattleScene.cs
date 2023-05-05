using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
	internal class BattleScene : Scene
	{
		/// <summary>
		/// 지금 현재 전투하고 있는 몬스터
		/// </summary>
		private Monster _curMonster; 

		public BattleScene(Game game) : base(game) 
		{
		}

		public override void Render()
		{
			game.Map();
		}

		public override void Update()
		{
			
		}

		public void BattleStart(Monster monster)
		{
			_curMonster = monster;
			MapData.monsters.Remove(_curMonster); //전투 중인 몬스터는 전투 이후 맵에 나오면 안되니 몬스터 리스트에서는 삭제함 

			Console.Clear();

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(@"	  _____                      _____                  _____                  _____                      _____            _____            ");
			sb.AppendLine(@"         /\    \                    /\    \                /\    \                /\    \                    /\    \          /\    \         	");
			sb.AppendLine(@"        /::\    \                  /::\    \              /::\    \              /::\    \                  /::\____\        /::\    \        	");
			sb.AppendLine(@"       /::::\    \                /::::\    \             \:::\    \             \:::\    \                /:::/    /       /::::\    \       	");
			sb.AppendLine(@"      /::::::\    \              /::::::\    \             \:::\    \             \:::\    \              /:::/    /       /::::::\    \      	");
			sb.AppendLine(@"     /:::/\:::\    \            /:::/\:::\    \             \:::\    \             \:::\    \            /:::/    /       /:::/\:::\    \     	");
			sb.AppendLine(@"    /:::/__\:::\    \          /:::/__\:::\    \             \:::\    \             \:::\    \          /:::/    /       /:::/__\:::\    \    	");
			sb.AppendLine(@"   /::::\   \:::\    \        /::::\   \:::\    \            /::::\    \            /::::\    \        /:::/    /       /::::\   \:::\    \   	");
			sb.AppendLine(@"  /::::::\   \:::\    \      /::::::\   \:::\    \          /::::::\    \          /::::::\    \      /:::/    /       /::::::\   \:::\    \  	");
			sb.AppendLine(@" /:::/\:::\   \:::\ ___\    /:::/\:::\   \:::\    \        /:::/\:::\    \        /:::/\:::\    \    /:::/    /       /:::/\:::\   \:::\    \ 	");
			sb.AppendLine(@"/:::/__\:::\   \:::|    |  /:::/  \:::\   \:::\____\      /:::/  \:::\____\      /:::/  \:::\____\  /:::/____/       /:::/__\:::\   \:::\____\	");
			sb.AppendLine(@"\:::\   \:::\  /:::|____|  \::/    \:::\  /:::/    /     /:::/    \::/    /     /:::/    \::/    /  \:::\    \       \:::\   \:::\   \::/    /	");
			sb.AppendLine(@" \:::\   \:::\/:::/    /    \/____/ \:::\/:::/    /     /:::/    / \/____/     /:::/    / \/____/    \:::\    \       \:::\   \:::\   \/____/ 	");
			sb.AppendLine(@"  \:::\   \::::::/    /              \::::::/    /     /:::/    /             /:::/    /              \:::\    \       \:::\   \:::\    \     	");
			sb.AppendLine(@"   \:::\   \::::/    /                \::::/    /     /:::/    /             /:::/    /                \:::\    \       \:::\   \:::\____\    	");
			sb.AppendLine(@"    \:::\  /:::/    /                 /:::/    /      \::/    /              \::/    /                  \:::\    \       \:::\   \::/    /    	");
			sb.AppendLine(@"     \:::\/:::/    /                 /:::/    /        \/____/                \/____/                    \:::\    \       \:::\   \/____/     	");
			sb.AppendLine(@"      \::::::/    /                 /:::/    /                                                            \:::\    \       \:::\    \         	");
			sb.AppendLine(@"       \::::/    /                 /:::/    /                                                              \:::\____\       \:::\____\        	");
			sb.AppendLine(@"        \::/____/                  \::/    /                                                                \::/    /        \::/    /        	");
			sb.AppendLine(@"         ~~                         \/____/                                                                  \/____/          \/____/         	");
			
			Console.WriteLine(sb.ToString()); ;


			Thread.Sleep(30000);
        }
	}
}
