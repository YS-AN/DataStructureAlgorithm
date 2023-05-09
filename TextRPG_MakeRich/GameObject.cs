using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_MakeRich.Utils;

namespace TextRPG_MakeRich
{
	public class GameObject
	{
		private char _icon;
		public char ICON { private set { _icon = value; } get { return _icon; } }

		protected GameObject(char icon)
		{
			_icon = icon;
		}

		protected Position _currentPos;

		protected void Move(MapItem[,] map, Direction direction)
		{
			Position prevPos = _currentPos;

			switch (direction)
			{
				case Direction.Up:
					_currentPos.y--;
					break;
				case Direction.Down:
					_currentPos.y++;
					break;
				case Direction.Left:
					_currentPos.x--;
					break;
				case Direction.Right:
					_currentPos.x++;
					break;
			}

			// 이동한 자리가 벽일 경우
			if (map[_currentPos.y, _currentPos.x] == MapItem.Wall && IsCanGo())
			{
				// 원위치 시키기
				_currentPos = prevPos;
			}
		}

		/// <summary>
		/// 이동위치가 벽 외의 다른 조건에 의해 이동할 수 없는 경우 조건 추가
		/// </summary>
		/// <returns></returns>
		protected virtual bool IsCanGo()
		{
			return true;
		}
		
		
	}
}
