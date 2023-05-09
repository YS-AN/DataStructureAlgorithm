using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_MakeRich.Utils;

namespace TextRPG_MakeRich.Attack
{
	public class Bubble : GameObject
	{
		private Direction _bubbleDir { get; set; }

		private int _moveCount;
		private int _power;

		public Bubble(Position position, Direction bubbleDir, int power) : base('○')
		{
			_moveCount = 0;
			_currentPos = position;
			_bubbleDir = bubbleDir;
			_power = power;

			GameData.Map.OnGetPrintMap += PrintBubble;
			
		}

		public Position CurrentPos { get { return _currentPos; } }

		public void PrintBubble()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.SetCursorPosition(_currentPos.x * 2, _currentPos.y);
			Console.Write(ICON);
		}

		public bool MoveAction()
		{
			if(_moveCount++ >= _power)
			{
				if (GameData.Map != null)
				{
					RemoveBubble();
					return false;
				}
			}
			else
			{
				GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.None;

				var prvPos = _currentPos;
				Move(GameData.Map.map, _bubbleDir);

				GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.Bubble;

				if (prvPos.x == _currentPos.x && prvPos.y == _currentPos.y)
				{
					RemoveBubble();
					return false;
				}
			}
			return true;
		}

		private void RemoveBubble()
		{
			GameData.Map.OnGetPrintMap -= this.PrintBubble;
			GameData.Map.map[_currentPos.y, _currentPos.x] = MapItem.None;
		}
	}
}
