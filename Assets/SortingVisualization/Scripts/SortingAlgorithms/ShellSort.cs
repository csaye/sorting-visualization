﻿using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class ShellSort
    {
        private static SortingStacks sortingStacks;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            int stackCount = sortingStacks.stackCount;
            int[] stacks = sortingStacks.stacks;
            int gap = stackCount / 2;
            while (gap >= 1)
            {
                for (int i = 0; i < gap; i++)
                {
                    for (int j = i; j < stackCount; j += gap)
                    {
                        int smallest = int.MaxValue;
                        for (int k = j; k < stackCount; k += gap)
                        {
                            if (stacks[k] < smallest) smallest = stacks[k];
                        }
                        if (stacks[j] != smallest)
                        {
                            sortingStacks.SwapStacks(smallest, stacks[j]);
                            yield return new WaitForSeconds(sortingStacks.delay);
                        }
                    }
                }
                gap /= 2;
            }
            yield return null;
            sortingStacks.StopSort();
        }
    }
}
