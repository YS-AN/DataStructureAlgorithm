using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA10_Sort
{
	internal class Sorting
	{
		/******************************************************
		 * 선형 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n개를 확인하는 정렬
		 * 시간복잡도 : O(N^2)
		 ******************************************************/

		/// <summary>
		/// 선택정렬
		/// 데이터를 전부 확인하면서, 그 중 가장 작은 값부터 하나씩 선택하여 정렬
		/// </summary>
		/// <param name="list"></param>
		public void SelectionSort(IList<int> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int minIndex = i;
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[j] < list[minIndex])
						minIndex = j; 
				}
				Swap(list, i, minIndex); //제일 작은 값을 현재 위치와 바꿈
			}
		}

		/// <summary>
		/// 삽입정렬
		/// 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
		/// </summary>
		/// <param name="list"></param>
public void InsertionSort(IList<int> list)
{
	for (int i = 1; i < list.Count; i++)
	{
		int key = list[i]; //데이터를 꺼냄
		int j = i - 1; //현재 위치 다음 인덱스부터 확인 함. (현재 위치보다 이전 위치는 이미 정렬된 데이터이기 때문에 확인할 필요 없음)
		for (; j >= 0 && key < list[j]; j--)
		{
			list[j + 1] = list[j];
		}
		list[j + 1] = key;
	}
}

		/// <summary>
		/// 버블정렬
		/// 서로 인접한 데이터를 비교하여 정렬
		/// (ex.키순으로 줄 세우기)
		/// 전체를 순회했는데 한번도 swap을 안 했다? 그럼 즉시 종료함 -> 버블정렬의 최적화
		/// </summary>
		/// <param name="list"></param>
		public void BubbleSort(IList<int> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 1; j < list.Count; j++)
				{
					if (list[j - 1] > list[j])
						Swap(list, j - 1, j);
				}
			}
		}

		/******************************************************
		 * 분할정복 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체의 1/2를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n/2개를 확인하는 정렬
		 * 시간복잡도 : O(NlogN)
		 ******************************************************/

		/// <summary>
		/// 힙정렬
		/// 힙을 이용하여 우선순위가 가장 높은 요소부터 가져와 정렬
		/// </summary>
		/// <param name="list"></param>
		public void HeapSort(IList<int> list)
		{
			PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

			for (int i = 0; i < list.Count; i++)
			{
				pq.Enqueue(list[i], list[i]);
			}

			for (int i = 0; i < list.Count; i++)
			{
				list[i] = pq.Dequeue();
			}
		}

		/// <summary>
		/// 병합정렬
		/// 데이터를 2분할하여 정렬 후 합치는 과정을 반복함 (분할정복 정렬형태)
		/// </summary>
		/// <param name="list"></param>
		/// <param name="left"></param>
		/// <param name="right"></param>
		public void MergeSort(IList<int> list, int left, int right)
		{
			if (left == right) return;

			int mid = (left + right) / 2;
			MergeSort(list, left, mid);
			MergeSort(list, mid + 1, right);
			Merge(list, left, mid, right);
		}

		public void Merge(IList<int> list, int left, int mid, int right)
		{
			List<int> sortedList = new List<int>();
			int leftIndex = left;
			int rightIndex = mid + 1;

			// 분할 정렬된 List를 병합
			while (leftIndex <= mid && rightIndex <= right)
			{
				if (list[leftIndex] < list[rightIndex])
					sortedList.Add(list[leftIndex++]);
				else
					sortedList.Add(list[rightIndex++]);
			}

			if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
			{
				for (int i = rightIndex; i <= right; i++)
					sortedList.Add(list[i]);
			}
			else  // 오른쪽 List가 먼저 소진 됐을 경우
			{
				for (int i = leftIndex; i <= mid; i++)
					sortedList.Add(list[i]);
			}

			// 정렬된 sortedList를 list로 재복사
			for (int i = left; i <= right; i++)
			{
				list[i] = sortedList[i - left];
			}
		}

		/// <summary>
		/// 퀵정렬
		/// 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
		/// 분할하고 나서는, 왼쪽을 기준으로 오른쪽 그룹은 당연히 왼쪽 보다 큰 값임 -> 2분법적으로 움직임 -> nlogN만큼의 시간이 걸리게 되는 것
		/// </summary>
		/// <param name="list"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		public void QuickSort(IList<int> list, int start, int end)
		{
			if (start >= end) return;

			int pivotIndex = start;
			int leftIndex = pivotIndex + 1;
			int rightIndex = end;

			while (leftIndex <= rightIndex) // 엇갈릴때까지 반복 -> 엇길리면 모든 데이터를 pivot 기준으로 나눈 것.
			{
				//피멋 기준으로 왼쪽, 오른쪽으로 구분하려면,
				//왼쪽에서부터 피벗보다 큰 값, 오른쪽에서 부터 피벗보다 작은 값을 만나면 둘의 위치를 바꿈

				// pivot보다 큰 값을 만날때까지
				while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)
					leftIndex++; //교환하면 오른쪽으로 한 칸 이동
				while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)
					rightIndex--; //교환하면 왼쪽으로 한 칸 이동

				
				
				if (leftIndex < rightIndex) // 엇갈리지 않았다면, 왼쪽 피벗 정렬 진행 중임.
					Swap(list, leftIndex, rightIndex);  // 분할 된 데이터 그룹의 왼쪽을 다시 퀵정렬함.
														// -> left ~ right까지 (right가 한 칸씩 왼쪽으로 이동하니까 중간 위치쯤까지 이동 됨)
				else    // 엇갈렸다면, 왼쪽은 정렬이 완료 된 것이니 오른쪽을 정렬 시작!
					Swap(list, pivotIndex, rightIndex); //index ~ right까지
			}

			QuickSort(list, start, rightIndex - 1);
			QuickSort(list, rightIndex + 1, end);

		}

		private void Swap(IList<int> list, int left, int right)
		{
			int temp = list[left];
			list[left] = list[right];
			list[right] = temp;
		}
	}
}
