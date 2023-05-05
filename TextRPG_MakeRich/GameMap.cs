using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich
{
	public class GameMap
	{
		private int mapWidth;
		private int mapHeight;
		private bool[,] map;

		/// <summary>
		/// 맵을 생성한다.
		/// </summary>
		/// <param name="width">너비</param>
		/// <param name="height">높이</param>
		/// <param name="depth">레벨 (5, 7) -> 5가 가장 복잡함</param>
		/// <returns></returns>
		public bool[,] CreatedMap(int width, int height, int depth)
		{
			mapWidth = width;
			mapHeight = height;
			map = new bool[width, height];


			// Start by filling the entire map with available space
			for (int x = 0; x < mapWidth; x++)
			{
				for (int y = 0; y < mapHeight; y++)
				{
					map[x, y] = true;
				}
			}

			// Add walls to the map using the BSP algorithm
			SplitRectangle(new Rectangle(0, 0, mapWidth, mapHeight), depth);

			MakeMapBorder();
			return map;
		}

		//const int standardNum = 7; //8
		const int splitNum = 4; //3

		/// <summary>
		/// 맵을 랜덤으로 쪼개면서 벽을 만듦
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="depth"></param>
		private void SplitRectangle(Rectangle rect, int depth)
		{
			Random random = new Random();

			// If the rectangle is too small, stop dividing
			if (rect.Width < depth || rect.Height < depth)
				return;

			// Choose a random axis to divide the rectangle along
			bool splitHorizontally = (random.Next(0, 2) == 0);

			// Choose a random position along the chosen axis to make the split
			int randomMax = splitHorizontally ? rect.Height - splitNum : rect.Width - splitNum;
			int splitPosition = random.Next(splitNum, randomMax < splitNum ? splitNum : randomMax);

			// Create two new rectangles based on the split position
			Rectangle rect1, rect2;
			if (splitHorizontally)
			{
				rect1 = new Rectangle(rect.Left, rect.Top, rect.Width, splitPosition);
				rect2 = new Rectangle(rect.Left, rect.Top + splitPosition, rect.Width, rect.Height - splitPosition);
			}
			else
			{
				rect1 = new Rectangle(rect.Left, rect.Top, splitPosition, rect.Height);
				rect2 = new Rectangle(rect.Left + splitPosition, rect.Top, rect.Width - splitPosition, rect.Height);
			}

			// Recursively split the two new rectangles
			SplitRectangle(rect1, depth);
			SplitRectangle(rect2, depth);

			// Add walls around the split line
			if (splitHorizontally)
			{
				int xPos = rect.Left + random.Next(1, rect.Width - 1);
				for (int y = rect.Top + splitPosition - (splitNum - 1); y <= rect.Top + splitPosition + (splitNum - 1); y++)
				{
					if (xPos >= rect.Left && xPos < rect.Right && y < mapHeight)
					{
						map[xPos, y] = false;
					}
				}
			}
			else
			{
				int yPos = rect.Top + random.Next(1, rect.Height - 1);
				for (int x = rect.Left + splitPosition - (splitNum - 1); x <= rect.Left + splitPosition + (splitNum - 1); x++)
				{
					if (yPos >= rect.Top && yPos < rect.Bottom && x < mapWidth)
					{
						map[x, yPos] = false;
					}
				}
			}
		}

		/// <summary>
		/// 맵의 테두리를 그린다
		/// </summary>
		private void MakeMapBorder()
		{
			for (int i = 0; i < mapWidth; i++)
			{
				map[0, i] = false;
				map[mapWidth - 1, i] = false;
				map[i, 0] = false;
				map[i, mapHeight - 1] = false;
			}
		}
	}


	// A simple rectangle class to represent the game space
	public class Rectangle
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;

		public int Width { get { return Right - Left; } }
		public int Height { get { return Bottom - Top; } }

		public Rectangle(int left, int top, int width, int height)
		{
			this.Left = left;
			this.Top = top;
			this.Right = left + width;
			this.Bottom = top + height;
		}
	}
}
