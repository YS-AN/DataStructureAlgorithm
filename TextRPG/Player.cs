using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
	public class Player
	{
		public char ICON { get { return '♣'; } }

		public Position position;

		/// <summary>
		/// 실제 움직임을 구현
		/// </summary>
		/// <param name="direction"></param>
		public void Move(Direction direction)
		{
			Position prevPos = position;
			// 플레이어 이동
			switch (direction)
			{
				case Direction.Up:
					position.y--;
					break;
				case Direction.Down:
					position.y++;
					break;
				case Direction.Left:
					position.x--;
					break;
				case Direction.Right:
					position.x++;
					break;
			}

			// 이동한 자리가 벽일 경우
			if (!MapData.map[position.y, position.x])
			{
				// 원위치 시키기
				position = prevPos;
			}
		}
	}
}
