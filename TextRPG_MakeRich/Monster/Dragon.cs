using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_MakeRich.Map;

namespace TextRPG_MakeRich
{
	internal class Dragon : Monster
	{
		public Dragon(int id) : base('§', id) { _damagePoint = 5; }

		private int _damagePoint;

		public static Dragon CreatedDragon(int id, ConsoleColor objColor)
		{
			Dragon newDragon = new Dragon(id);
			newDragon.objColor = objColor;
			newDragon._currentPos = newDragon.GetAccessiblePosition();
			GameData.Map.OnGetPrintMap += newDragon.PrintObject;

			return newDragon;
		}

		public override void MoveAction()
		{
			if (MoveCount++ % 5 == 0) //5번에 한번만 움직임Damage
			{
				return;
			}

			GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.None;

			AStar aster = new AStar();

			List<Point> path;
			Point movePoint = new Point(_currentPos.x, _currentPos.y);
			Point targetPoint = new Point(GameData.player.CurrentPos.x, GameData.player.CurrentPos.y);
			bool result = aster.PathFinding(GameData.Map.map, movePoint, targetPoint, out path);

			Random random = new Random();
			Move(GameData.Map.map, (Direction)random.Next(0, 4));


			if (GameData.Map.map[_currentPos.y, _currentPos.x] == MapItem.Bubble)
			{
				if(_damagePoint > 0)
				{
					_damagePoint--;
					GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.Monster;
				}
				else
				{
					GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.Bubble;
				}
			}
			GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.Monster;
		}

	}
}
