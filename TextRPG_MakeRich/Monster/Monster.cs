using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich
{
	public abstract class Monster
	{/*
		public Monster(char icon)
		{
			MoveCount = 0;
			_icon = icon;
		}

		private char _icon;
		public char ICON { private set { _icon = value; } get { return _icon; } }

		public Position position;

		/// <summary>
		/// 움직임 규칙 기록
		/// </summary>
		protected int MoveCount;

		/// <summary>
		/// 몬스터의 움직임
		///	-> 몬스터마다 움직임이 다 달라 -> 움직이는 방법은 몬스터를 상속받은 클래스에서 구현하도록 유도함
		/// </summary>
		public abstract void MoveAction();

		/// <summary>
		/// 움직임 구현
		/// </summary>
		/// <param name="direction"></param>
		public void Move(Direction direction)
		{
			Position prevPos = position;

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

		//*/
	}
}
