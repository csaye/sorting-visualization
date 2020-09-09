using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortingVisualization
{
    public class HeapSort
    {
        // private class Node
        // {
        //     public Node(int stack_) { stack = stack_; }
        //     public int stack = -1;
        //     public Node childA = null;
        //     public Node childB = null;
        // }

        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;
        private static float sortDelay = SortingStacks.sortDelay;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;

            for (int i = (stackCount / 2) - 1; i >= 0; i--)
            {
                bool sorting = true;
                int[] arr = sortingStacks.stacks;
                int size = stackCount;
                int index = i;
                while (sorting)
                {
                    int largest = index;
                    int left = (2 * index) + 1;
                    int right = (2 * index) + 2;
                    if (left < size && arr[left] > arr[largest]) largest = left;
                    if (right < size && arr[right] > arr[largest]) largest = right;
                    if (largest != index)
                    {
                        sortingStacks.SwapStackIndices(index, largest);
                        yield return new WaitForSeconds(sortDelay);
                        index = largest;
                    }
                    else sorting = false;
                }
            }
            for (int i = stackCount - 1; i > 0; i--)
            {
                sortingStacks.SwapStackIndices(0, i);
                yield return new WaitForSeconds(sortDelay);
                MakeBinaryHeap(sortingStacks.stacks, i, 0);
            }
            sortingStacks.StopSort();
            // sortingStacks = _sortingStacks;
            // for (int i = (stackCount / 2) - 1; i >= 0; i--) MakeBinaryHeap(sortingStacks.stacks, stackCount, i);
            // for (int i = stackCount - 1; i > 0; i--)
            // {
            //     sortingStacks.SwapStackIndices(0, i);
            //     yield return new WaitForSeconds(sortDelay);
            //     MakeBinaryHeap(sortingStacks.stacks, i, 0);
            // }
            // sortingStacks.StopSort();
        }

        private static void MakeBinaryHeap(int[] arr, int size, int index)
        {
            int largestIndex = index;
            int leftIndex = (2 * index) + 1;
            int rightIndex = (2 * index) + 2;
            if (leftIndex < size && arr[leftIndex] > arr[largestIndex]) largestIndex = leftIndex;
            if (rightIndex < size && arr[rightIndex] > arr[largestIndex]) largestIndex = rightIndex;
            if (largestIndex != index)
            {
                sortingStacks.SwapStackIndices(index, largestIndex);
                MakeBinaryHeap(arr, size, largestIndex);
            }
        }
    }
}
