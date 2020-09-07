using System;
using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class QuickSort
    {
        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;
        private static float sortDelay = SortingStacks.sortDelay;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;

            int pivot = GetPivotStack(sortingStacks.stacks, 0, stackCount);
            sortingStacks.SetStack(pivot, stackCount / 2);
            for (int i = 0; i < stackCount / 2; i++)
            {
                if (sortingStacks.stacks[i] < pivot)
                {
                    for (int j = stackCount / 2; j < stackCount; j++)
                    {
                        if (pivot < sortingStacks.stacks[j]) continue;
                        sortingStacks.SwapStackIndices(i, j);
                        yield return new WaitForSeconds(sortDelay);
                        break;
                    }
                }
            }

            sortingStacks.StopSort();
        }

        // private static IEnumerator Partition(int startIndex, int endIndex)
        // {
        //     int midIndex = (startIndex + endIndex) / 2;
        //     int pivot = GetPivotStack(sortingStacks.stacks, startIndex, endIndex);
        //     sortingStacks.SetStack(pivot, midIndex);
        //     for (int i = startIndex; i < midIndex; i++)
        //     {
        //         if (sortingStacks.stacks[i] > pivot)
        //         {
        //             for (int j = midIndex + 1; j < endIndex; j++)
        //             {
        //                 if (sortingStacks.stacks[j] > sortingStacks.stacks[i]) continue;
        //                 sortingStacks.SwapStackIndices(i, j);
        //                 yield return new WaitForSeconds(sortDelay);
        //                 break;
        //             }
        //         }
        //     }
        // }

        private static int GetPivotStack(int[] stacks, int startIndex, int endIndex)
        {
            int[] sortedStacks = new int[endIndex - startIndex];
            for (int i = startIndex; i < endIndex; i++) sortedStacks[i] = stacks[i];
            Array.Sort(sortedStacks);
            return sortedStacks[sortedStacks.Length / 2];
        }
    }
}
