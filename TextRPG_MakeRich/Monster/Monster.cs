using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_MakeRich.Utils;

namespace TextRPG_MakeRich
{
	public abstract class Monster : GameObject
	{
		public int Id { get; private set; }

		/// <summary>
		/// 움직임 규칙 기록
		/// </summary>
		protected int MoveCount;
		protected ConsoleColor objColor;

		public Position CurrentPos { get { return _currentPos; } }

		public Monster(char icon, int id) : base(icon)
		{
			Id = id;
			MoveCount = 0;
			objColor = ConsoleColor.White;
		}

		public abstract void MoveAction();

		public Position GetAccessiblePosition()
		{
			Random random = new Random();

			int x, y;
			do
			{
				x = random.Next(1, GameData.Map.MapHeight);
				y = random.Next(1, GameData.Map.MapWidth);
			}
			while (GameData.Map.map[x, y] != MapItem.None);

			return new Position(y, x);
		}

		public void PrintObject()
		{
			Console.ForegroundColor = objColor;
			Console.SetCursorPosition(_currentPos.x * 2, _currentPos.y);
			Console.Write(ICON);
		}

		public void Die()
		{
			if(GameData.Map != null)
			{
				GameData.Map.OnGetPrintMap -= this.PrintObject;
			}
		}
	}
}
