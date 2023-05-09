using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich.Map
{
	/// <summary>
	/// A* 알고리즘
	/// </summary>
	internal class AStar
	{
		/// <summary>
		/// 직선 거리
		/// </summary>
		const int CostStraight = 10;

		/// <summary>
		/// 대각선 거리 -> 직선거리 루트 2
		/// </summary>
		const int CostDiagonal = 14;

		/// <summary>
		/// 상하좌우 + 대각선 방향을 추가함
		/// </summary>
		Point[] Direction =
		{
			new Point (0, 1),  //상
			new Point (0, -1), //하
			new Point (-1, 0), //좌
			new Point (1, 0),  //우
			new Point( -1, 1 ),	 // 좌상
			new Point( -1, -1 ), // 좌하
			new Point( 1, 1 ),	 // 우상
			new Point( 1, -1 )	 // 우하
		};

		/// <summary>
		/// A* 알고리즘을 활용하여 경로 탐색
		/// </summary>
		/// <param name="tileMap"></param>
		/// <param name="start">시작 지점</param>
		/// <param name="end">도착 지점</param>
		/// <param name="path">경로</param>
		/// <returns></returns>
		public bool PathFinding(MapItem[, ] tileMap, Point start, Point end, out List<Point> path)
		{
			int ySize = tileMap.GetLength(0);
			int xSize = tileMap.GetLength(1);

			bool[, ] visited = new bool[ySize, xSize];
			ASNode[, ] nodes = new ASNode[ySize, xSize];
			PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>(); //f가 가장 작은 것부터 탐색을 해야 하기 때문에 우선순위 큐를 활용함. 
																					   //node와 f값만 넣어두면 f값이 가장 낮은 순서부터 자동으로 꺼내짐.

			//시작 정점 생성
			ASNode startNode = new ASNode(start, null, 0, GetHeuristics(start, end)); //유일하게 parent노드 값이 없는 node
			nodes[startNode.point.y, startNode.point.x] = startNode;
			nextPointPQ.Enqueue(startNode, startNode.f);

			while(nextPointPQ.Count > 0)
			{
				//다음으로 탐색할 정점을 꺼내기
				ASNode nextNode = nextPointPQ.Dequeue();

				//방문한 정점은 방문표시로 변경
				visited[nextNode.point.y, nextNode.point.x] = true;


				//탐색할 정점이 도착지라면? -> 탐색 종료 -> 경로 반환
				if(nextNode.point.x == end.x && nextNode.point.y == end.y) //todo. ==연산자 오퍼레이터 활용하기
				{
					path = GetPath(nodes, end);
					return true;
				}

				//AStart 탐색 진행
				for (int i=0; i<Direction.Length; i++) //미리 Direction에 상하좌우에 대한 이동 좌표 값을 넣어두고, for문 돌려서 쉽게 위치를 찾을 수 있음
				{
					int x = nextNode.point.x + Direction[i].x;
					int y = nextNode.point.y + Direction[i].y;


					//탐색할 수 없는 경우는 제외함
					if(x < 0 || x >= xSize || y < 0 || y >= ySize) //맵을 벗어나는 경우
						continue;
					
					else if (tileMap[y, x] != MapItem.None) // 탐색할 수 없는 정점일 경우 (장애물이나 벽이 있는 경우)
						continue;
					
					else if (visited[y, x]) // 이미 방문한 정점일 경우
						continue;

					//탐색 = f값을 결정하는 행위임
					//int g = nextNode.g + CostStraight;
					int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal); //대각선 이동을 고려함
					int h = GetHeuristics(new Point(x, y), end);

                    //Console.WriteLine($"[{y}, {x}] = {h}");

                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

					//정점의 갱신이 필요한 경우만 새로운 정점으로 할당을 함. 
					if (nodes[y, x] == null // 한번도 탐색 되지 않았던 경우 -> 계산이 되어 있지 않은 정점
							|| nodes[y, x].f > newNode.f) //기존에 계산된 값이 있을 때, 기존 값보다 새로운 정점에서 계산한 값이 더 작은 경우에만 갱신
					{
						nodes[y, x] = newNode;
						nextPointPQ.Enqueue(newNode, newNode.f);
					}
				}

			}

			//모든 경로를 탄색했는데 도착지점에 도달하지 못함. -> 해당 도착지점으로 갈 수 있는 경로가 없는 것임. 
			path = null;
			return false; //못찾음

		}

		/// <summary>
		/// h(heuristic)값을 계산해서 반환함 
		/// h(heuristic) : 최상의 경로를 추정하는 순위 값 -> h에 의해 경로 탐색 효율이 결정 됨 
		/// </summary>
		/// <param name="start">시작 지점</param>
		/// <param name="end">도착 지점</param>
		/// <returns></returns>
		private int GetHeuristics(Point start, Point end)
		{
			int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
			int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

			// 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
			// return CostStraight * (xSize + ySize);

			// 유클리드 거리 : 대각선을 통해 이동하는 거리
			//	-> 유클리드 거리에서는 피타고라스 정리를 활용하기 때문에 보통 대각선 거리를 직선거리 루트 2로 함
			return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
		}

		private List<Point> GetPath(ASNode[,] nodes, Point? pathPoint)
		{
			List<Point> path = new List<Point>();

			while (pathPoint != null) //시작 지점에 갈 때까지 반복
			{
				Point point = pathPoint.GetValueOrDefault(); //pathPoint가 nullable이라 바로는 못 놓고 GetValueOrDefault 활용
				path.Add(point);
				pathPoint = nodes[point.y, point.x].parent;
			}

			//경로를 종료지점부터 시작 지점까지 따라가도록 저장함 -> 역순으로 저장되어 있음 -> 다시 한번 뒤집어주면 시작지점부터 나오게 할 수 있음
			path.Reverse(); //배열 뒤집기

			return path;
		}

		public void PrintResult(in bool[,] tileMap, in List<Point> path)
		{
			char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];
			for (int y = 0; y < pathMap.GetLength(0); y++)
			{
				for (int x = 0; x < pathMap.GetLength(1); x++)
				{
					if (tileMap[y, x])
						pathMap[y, x] = ' ';
					else
						pathMap[y, x] = '■';
				}
			}

			foreach (Point point in path)
			{
				pathMap[point.y, point.x] = '*';
			}

			Point start = path.First();
			Point end = path.Last();
			pathMap[start.y, start.x] = 'S';
			pathMap[end.y, end.x] = 'E';

			for (int i = 0; i < pathMap.GetLength(0); i++)
			{
				for (int j = 0; j < pathMap.GetLength(1); j++)
				{
					Console.Write(pathMap[i, j] == '■' ? pathMap[i, j] : $"{pathMap[i, j]} ");
				}
				Console.WriteLine();
			}
		}

		//구조체는 빈 데이터를 가질 수 없지만, 탐색을 진행하다 보면 빈 데이터가 생길 수도 있어. -> 구조체가 아닌 클래스를 사용함
		private class ASNode
		{
			public Point point; //현재 위치
			public Point? parent; //어떤 정점에서부터 탐색 당했는지 -> 상위 정점에 대한 정보. 
								  //출발지점은 부모 좌표가 없기 때문에 변수 타입을 nullable로 지정함

			//public int f { get { return g + h; } } //f(x) = g(x) + h(x) = 총 거리
			public int f;
			public int g; //현재까지의 거리 -> 지금까지 경로의 가중치 
			public int h; //(Heuristic) 도착지점까지 남은 예상 거리 

			public ASNode(Point point, Point? parent, int g, int h)
			{
				this.point = point;
				this.parent = parent;
				this.g = g;
				this.h = h;
				this.f = g + h;
			}
		}
	}

	/// <summary>
	/// 좌표계
	/// </summary>
	public struct Point
	{
		public int x;
		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
