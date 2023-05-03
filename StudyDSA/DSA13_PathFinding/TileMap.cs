using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA13_PathFinding
{
	internal class TileMap
	{
		// <타일맵 그래프>
		// 예시 - 위치의 이동가능 표현한 이차원 타일맵
		public bool[,] tileMap1 = new bool[7, 7]
		{
			{ false, false, false, false, false, false, false },
			{ false,  true,  true, false, false, false, false },
			{ false, false,  true, false, false,  true, false },
			{ false, false,  true,  true,  true,  true, false },
			{ false, false,  true, false, false, false, false },
			{ false, false,  true,  true,  true,  true, false },
			{ false, false, false, false, false, false, false },
		};
		/*
		 * ■ ■ ■ ■ ■ ■ ■
		 * ■   ■   ■ ■ ■
		 * ■   ■   ■   ■
		 * ■   ■       ■
		 * ■   ■   ■ ■ ■
		 * ■           ■
		 * ■ ■ ■ ■ ■ ■ ■
		 */

		// 예시 - 타일의 종류를 표현한 이차원 타일맵
		enum TileType
		{
			None = ' ',
			Wall = '■',
			Path = '*',
			Start = 'S',
			Goal = 'E',
		}

		public char[,] tileMap2 = new char[9, 9]
		{
			{ '■', '■', '■', '■', '■', '■', '■', '■', '■' },
			{ '■', 'S', '■', '■', ' ', ' ', '■', '■', '■' },
			{ '■', '*', '■', '■', ' ', '■', '■', ' ', '■' },
			{ '■', '*', '■', '■', ' ', '■', '■', ' ', '■' },
			{ '■', '*', '■', '*', '*', '*', '*', '*', '■' },
			{ '■', '*', '■', '*', '■', '■', '■', '*', '■' },
			{ '■', '*', '■', '*', '■', '■', '■', '*', '■' },
			{ '■', '*', '*', '*', '■', '■', '■', 'E', '■' },
			{ '■', '■', '■', '■', '■', '■', '■', '■', '■' },
		};
		/*
		 * ■ ■ ■ ■ ■ ■ ■ ■ ■
		 * ■ S ■ ■     ■ ■ ■
		 * ■ * ■ ■   ■ ■   ■
		 * ■ * ■ ■   ■ ■   ■
		 * ■ * ■ * * * * * ■
		 * ■ * ■ * ■ ■ ■ * ■
		 * ■ * ■ * ■ ■ ■ * ■
		 * ■ * * * ■ ■ ■ E ■
		 * ■ ■ ■ ■ ■ ■ ■ ■ ■
		 */

		public void PrintTile(bool[,] map)
		{
			for(int i=0; i<map.GetLength(0); i++)
			{
				for(int j=0; j<map.GetLength(1); j++)
				{
					Console.Write(map[i, j] ? "  " : "■");
                }
                Console.WriteLine();
            }
        }

		public void PrintTile(char[,] map)
		{
			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					Console.Write(map[i, j] == '■' ? map[i, j] : map[i, j] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
