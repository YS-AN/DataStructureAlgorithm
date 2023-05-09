using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_MakeRich.Attack;
using TextRPG_MakeRich.Utils;

namespace TextRPG_MakeRich
{
	public class Player : GameObject
	{
		public int AttackPower { get; set; }

		public List<Bubble> Bubbles { get; set; }

		public Player() : base('♣')
		{
			_currentPos = new Position(1, 1);
			GameData.Map.OnGetPrintMap += PrintPlayer;

			AttackPower = 2;
			Bubbles = new List<Bubble>();
		}

		public Position CurrentPos { get { return _currentPos; } }

		public void PrintPlayer()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(_currentPos.x * 2, _currentPos.y);
			Console.Write(ICON);
		}

		public void MoveAction(Direction direction)
		{
			Move(GameData.Map.map, direction);
		}
		
		public void Attack(ConsoleKey inputKey)
		{
			switch(inputKey)
			{
				case ConsoleKey.W:
					_currentPos.y--;
					Bubbles.Add(new Bubble(_currentPos, Direction.Up, AttackPower));
					break;
				case ConsoleKey.A:
					_currentPos.x--;
					Bubbles.Add(new Bubble(_currentPos, Direction.Left, AttackPower));
					break;
				case ConsoleKey.S:
					_currentPos.y++;
					Bubbles.Add(new Bubble(_currentPos, Direction.Down, AttackPower));
					break;
				case ConsoleKey.D:
					_currentPos.x++;
					Bubbles.Add(new Bubble(_currentPos, Direction.Right, AttackPower));
					break;
			}
		}
	}
}
