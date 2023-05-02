using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA12_ShortestPath
{
	internal class Dijkstra
	{
		/******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 * 결론, 다이렉트로 가는 거리가 거쳐가는 거리보다 길면, 거쳐가는 거리로 바꿔 버리는 과정을 반복 -> 최단 거리만 남김 (거쳐가서 빠르면 무조건 그 경로를 씀!)
		 * 거쳐가는 경로 중 가장 짧은 것부터 우선적으로 탐색을 함
		 * 
		 ******************************************************/

		const int INF = 99999; //단절 -> 거리 계산 시 오버플로우 방지하기 위해 maxValue 사용하지 않음

		/// <summary>
		/// 다익스트라 알고리즘으로 최단 경로 구하기
		/// </summary>
		/// <param name="graph">가중치 있는 그래프</param>
		/// <param name="start">시작점</param>
		/// <param name="distance">최단 거리</param>
		/// <param name="path">경로 -> N번 거쳐서 도착함. (0이면 다이렉트로 감)</param>
		public void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
		{
			int size = graph.GetLength(0);
			bool[] visited = new bool[size]; //방문 여부 기록

			distance = new int[size];
			path = new int[size];

			for (int i = 0; i < size; i++)
			{
				distance[i] = graph[start, i]; //i번째에 대한 거리는 시작위치 부터 i까지
				path[i] = graph[start, i] < INF ? start : -1; //시작부터 i까지 가는 길이 연결되어 있으면, start지점을, 연결되어 있지 않으면 -1로 넣어줌
			}

			for (int i = 0; i < size; i++)
			{
				// 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
				int next = -1;
				int minCost = INF;
				for (int j = 0; j < size; j++)
				{
					if (!visited[j] && //방문하지 않은 정점
						distance[j] < minCost) //최단 경로보다 더 짧다면
					{
						next = j; //다음 확인 할 위치로 변경
						minCost = distance[j]; //최단 경로 값을 변경함
					}
				}
				if (next < 0)
					break;

				// 2. 직접연결된 거리보다 거쳐서 이동한 거리(next)가 더 짧아진다면 갱신.
				for (int j = 0; j < size; j++)
				{
					// cost[j] : 목적지까지 직접 연결된 거리
					// cost[next] : 탐색중인 정점까지 거리
					// graph[next, j] : 탐색중인 정점부터 목적지의 거리
					if (distance[j] > distance[next] + graph[next, j]) //직접적인 거리가, next를 거쳐 가는 거리보다 더 큰 경우에는 -> 갱신. 
					{
						distance[j] = distance[next] + graph[next, j];
						path[j] = next;
					}
				}
				visited[next] = true;
			}
		}

		public void PrintDijkstra(int[] distance, int[] path)
		{
			Console.Write("Vertex");
			Console.Write("\t");
			Console.Write("dist");
			Console.Write("\t");
			Console.WriteLine("path");

			for (int i = 0; i < distance.Length; i++)
			{
				Console.Write("{0,3}", i);
				Console.Write("\t");
				if (distance[i] >= INF)
					Console.Write("INF");
				else
					Console.Write("{0,3}", distance[i]);
				Console.Write("\t");
				if (path[i] < 0)
					Console.WriteLine("  X ");
				else
					Console.WriteLine("{0,3}", path[i]);
			}
		}

		private void PrintPath(int[] distance, int path, int start)
		{

		}
	}
}