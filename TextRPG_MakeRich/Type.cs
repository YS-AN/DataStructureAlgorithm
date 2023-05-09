using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich
{
	public enum MapLevel
	{
		//level = depth
		Easy = 7,
		Hard = 5
	}

	/// <summary>
	/// 방향정보
	/// </summary>
	public enum Direction 
	{ 
		Left, 
		Up, 
		Right, 
		Down 
	}

	public enum MapItem
	{
		None,
		Wall,
		Bubble,
		Monster
	}
}