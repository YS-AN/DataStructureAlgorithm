using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Utils;

namespace TextRPG
{
	/// <summary>
	/// 플레이어의 움직임을 추적하는 몬스터
	/// </summary>
	internal class Dragon : Monster
	{
		public Dragon() : base('☜') { }

		public override void MoveAction()
		{
			if(MoveCount++ %2 == 0)
			{
				return;
			}

			AStar aster = new AStar();

			List<Point> path;
			bool result = aster.PathFinding(MapData.map, new Point(position.x, position.y), new Point(MapData.player.position.x, MapData.player.position.y), out path);


			if(result)
			{
				//path[1] = 다음으로 이동할 위치
				if (path[1].y == position.y - 1)
				{
					Move(Direction.Up);
				}
				else if(path[1].y == position.y + 1)
				{
					Move(Direction.Down);
				}
				else if (path[1].x == position.x - 1)
				{
					Move(Direction.Left);
				}
				else
				{
					Move(Direction.Right);
				}
			}
			return;
		}
	}
}
