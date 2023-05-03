namespace DSA13_PathFinding
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TileMap map = new TileMap();
			map.PrintTile(map.tileMap1); Console.WriteLine();
            map.PrintTile(map.tileMap2); Console.WriteLine();

			AStar aStar = new AStar();
			bool result = false;

			bool[,] tileMap = new bool[9, 9]
			{
				{ false, false, false, false, false, false, false, false, false },
				{ false,  true,  true,  true, false, false, false,  true, false },
				{ false,  true, false,  true, false, false, false,  true, false },
				{ false,  true, false,  true,  true,  true,  true,  true, false },
				{ false,  true, false,  true, false, false, false,  true, false },
				{ false,  true, false,  true, false, false, false,  true, false },
				{ false, false, false, false, false, false, false,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true, false },
				{ false, false, false, false, false, false, false, false, false },
			};
			List<Point> path;

			result = aStar.PathFinding(tileMap, new Point(1, 1), new Point(1, 7), out path);
			if(result)
			{
				aStar.PrintResult(tileMap, path);
			}
			else
			{
                Console.WriteLine("탐색 실패");
            }

			bool[,] PracticeMap = new bool[10, 10]
			{
				{ false, false, false, false, false, false, false, false, false, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false,  true,  true,  true, false, false,  true,  true,  true, false },
				{ false,  true,  true,  true, false,  true,  true,  true,  true, false },
				{ false,  true,  true,  true, false,  true,  true,  true,  true, false },
				{ false,  true,  true,  true, false,  true,  true,  true,  true, false },
				{ false,  true,  true,  true, false,  true,  true,  true,  true, false },
				{ false,  true,  true,  true, false,  true,  true,  true,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true,  true, false },
				{ false, false, false, false, false, false, false, false, false, false },
			};
			result = aStar.PathFinding(PracticeMap, new Point(3, 3), new Point(7, 6), out path);


		}
	}
}