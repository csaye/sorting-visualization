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
                    if (endIndex > stackCount) continue;
                    if (endIndex + partitionSize > stackCount) endIndex = stackCount;
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
            while (!sortingStacks.StacksSorted())
            {
                for (int i = 0; i < stackCount; i++)
                {
                    if (i > 0 && stacks[i - 1] > stacks[i])
                    {
                        int j = i - 1;
                        while (j > 0 && stacks[j] > stacks[i]) j--;
                        sortingStacks.SetStack(stacks[i], j + 1);
                        yield return new WaitForSeconds(sortingStacks.delay);
                    }
                }
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
