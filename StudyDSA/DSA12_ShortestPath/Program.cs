namespace DSA12_ShortestPath
{
	internal class Program
	{
		static void Main(string[] args)
		{
			const int INF = 99999;

			int[,] graph = new int[9, 9]
			{
				{   0, INF,   1,   7, INF, INF, INF,   5, INF},
				{ INF,   0, INF, INF, INF,   4, INF, INF, INF},
				{ INF, INF,   0, INF, INF, INF, INF, INF, INF},
				{   5, INF, INF,   0, INF, INF, INF, INF, INF},
				{ INF, INF,   9, INF,   0, INF, INF, INF,   2},
				{   1, INF, INF, INF, INF,   0, INF,   6, INF},
				{ INF, INF, INF, INF, INF, INF,   0, INF, INF},
				{   1, INF, INF, INF,   4, INF, INF,   0, INF},
				{ INF,   5, INF,   2, INF, INF, INF, INF,   0}
			};


			int[] distance;
			int[] path;

			Dijkstra dijkstra = new Dijkstra();
			dijkstra.ShortestPath(in graph, 0, out distance, out path);
			Console.WriteLine("<Dijkstra>");
			dijkstra.PrintDijkstra(distance, path);

            Console.WriteLine("\n===========================================================\n");
			
            int[,] costTable;
			int[,] pathTable;
			FloydWarshall floydWarshall = new FloydWarshall();
			floydWarshall.ShortestPath(in graph, out costTable, out pathTable);
			Console.WriteLine("<Floyd-Warshall>");
			floydWarshall.PrintFloydWarshall(costTable, pathTable);
		}
	}

}