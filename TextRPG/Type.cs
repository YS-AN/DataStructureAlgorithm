using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
	/// <summary>
	/// 위치정보
	/// </summary>
	public struct Position
	{
		public int x;
		public int y;

		public Position(int x, int y)
		{
			this.x = x;	
			this.y = y;
		}
	}

	/// <summary>
	/// 방향정보
	/// </summary>
	public enum Direction { Left, Up, Right, Down }
}
