using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich.Map
{
    public class GameMap
    {
		const int splitNum = 4; //3

		public int MapWidth { get; private set; }
        public int MapHeight { get; private set; }
		public MapItem[,] map { get; private set; }

		public event Action OnGetPrintMap;

		/// <summary>
		/// 맵을 생성한다.
		/// </summary>
		/// <param name="width">너비</param>
		/// <param name="height">높이</param>
		/// <param name="level">맵 레벨 결정</param>
		/// <returns></returns>
		public void CreatedMap(int width, int height, MapLevel level)
        {
            MapWidth = width;
            MapHeight = height;
            map = new MapItem[width, height];

            // Start by filling the entire map with available space
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    map[x, y] = MapItem.None;
                }
            }

            // Add walls to the map using the BSP algorithm
            SplitRectangle(new Rectangle(0, 0, MapWidth, MapHeight), (int)level);

            MakeMapBorder();
        }

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
            bool splitHorizontally = random.Next(0, 2) == 0;

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
                    if (xPos >= rect.Left && xPos < rect.Right && y < MapHeight)
                    {
                        map[xPos, y] = MapItem.Wall;
                    }
                }
            }
            else
            {
                int yPos = rect.Top + random.Next(1, rect.Height - 1);
                for (int x = rect.Left + splitPosition - (splitNum - 1); x <= rect.Left + splitPosition + (splitNum - 1); x++)
                {
                    if (yPos >= rect.Top && yPos < rect.Bottom && x < MapWidth)
                    {
                        map[x, yPos] = MapItem.Wall;
                    }
                }
            }
        }

        /// <summary>
        /// 맵의 테두리를 그린다
        /// </summary>
        private void MakeMapBorder()
        {
            for (int i = 0; i < MapWidth; i++)
            {
                map[0, i] = MapItem.Wall;
                map[MapWidth - 1, i] = MapItem.Wall;
                map[i, 0] = MapItem.Wall;
                map[i, MapHeight - 1] = MapItem.Wall;
            }

            if (map[1, 1] == MapItem.Wall)
            {
                map[1, 1] = MapItem.None;
            }
        }

		/// <summary>
		/// 맵을 그림
		/// </summary>
		public void PrintMap()
		{
            Console.ForegroundColor = ConsoleColor.White;

			for (int y = 0; y < MapHeight; y++)
			{
				for (int x = 0; x < MapWidth; x++)
				{
                    if(GameData.Map.map[y, x] == MapItem.None)
                    {
                        Console.Write("　");

					}
					else if (GameData.Map.map[y, x] == MapItem.Wall)
                    {
						Console.Write("■");
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			OnGetPrintMap?.Invoke();
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
            Left = left;
            Top = top;
            Right = left + width;
            Bottom = top + height;
        }
    }
}
