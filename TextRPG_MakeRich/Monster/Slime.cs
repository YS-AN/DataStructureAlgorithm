using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_MakeRich.Map;
using TextRPG_MakeRich.Utils;

namespace TextRPG_MakeRich
{
	internal class Slime : Monster
	{
		public Slime(int id) : base('♨', id) { }

		public static Slime CreatedSlime(int id, ConsoleColor objColor)
		{
			Slime newSlime = new Slime(id);
			newSlime.objColor = objColor;
			newSlime._currentPos = newSlime.GetAccessiblePosition();
			GameData.Map.OnGetPrintMap += newSlime.PrintObject;

			return newSlime;
		}

		public override void MoveAction()
		{
			if (MoveCount++ % 3 == 0) //3번에 한번만 움직임
			{
				return;
			}

			GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.None;

			Random random = new Random();
			Move(GameData.Map.map, (Direction)random.Next(0, 4));

			if(GameData.Map.map[_currentPos.y, _currentPos.x] != MapItem.Bubble)
			{
				GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.Monster;
			}
		}
	}
}
