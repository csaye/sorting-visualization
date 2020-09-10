using System;
using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class QuickSort
    {
        private static SortingStacks sortingStacks;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            int stackCount = sortingStacks.stackCount;
            int[] stacks = sortingStacks.stacks;
            int partitionSize = stackCount;
            while (!sortingStacks.StacksSorted() && partitionSize > 1)
            {
                for (int startIndex = 0; startIndex < stackCount; startIndex += partitionSize)
                {
                    int endIndex = startIndex + partitionSize;
                    if (endIndex > stackCount) endIndex = stackCount;
                    int midIndex = (startIndex + endIndex) / 2;
                    int pivot = GetPivotStack(stacks, startIndex, endIndex);
                    sortingStacks.SetStack(pivot, midIndex);
                    for (int i = startIndex; i < midIndex; i++)
                    {
                        if (stacks[i] > pivot)
                        {
                            for (int j = midIndex + 1; j < endIndex; j++)
                            {
                                if (pivot < stacks[j]) continue;
                                sortingStacks.SwapStackIndices(i, j);
                                yield return new WaitForSeconds(sortingStacks.delay);
                                break;
                            }
                        }

                    }
                }
                partitionSize /= 2;
            }
            sortingStacks.StopSort();
        }

        private static int GetPivotStack(int[] stacks, int startIndex, int endIndex)
        {
            int[] sortedStacks = new int[endIndex - startIndex];
            for (int i = startIndex; i < endIndex; i++) sortedStacks[i - startIndex] = stacks[i];
            Array.Sort(sortedStacks);
            return sortedStacks[sortedStacks.Length / 2];
        }
    }
}
