using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class MergeSort
    {
        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;
        private static float sortDelay = SortingStacks.sortDelay;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            int groupCount = 0;
            int groupSize = 2;
            for (int i = 0; i < stackCount; i += groupSize)
            {
                groupCount++;
                if (i + (groupSize / 2) >= stackCount) break;
                if (sortingStacks.stacks[i] > sortingStacks.stacks[i + 1])
                {
                    sortingStacks.SwapStackIndices(i, i + 1);
                    yield return new WaitForSeconds(sortDelay);
                }
            }
            groupSize *= 2;
            while (groupCount > 1)
            {
                for (int i = 0; i < stackCount; i += groupSize)
                {
                    if (i + (groupSize / 2) >= stackCount) break;
                    for (int j = i; j < i + groupSize; j++)
                    {
                        int smallest = stackCount;
                        for (int k = j; k < i + groupSize; k++)
                        {
                            if (sortingStacks.stacks[k] < smallest) smallest = sortingStacks.stacks[k];
                        }
                        if (sortingStacks.stacks[j] != smallest)
                        {
                            sortingStacks.SetStack(smallest, j);
                            yield return new WaitForSeconds(sortDelay);
                        }
                    }
                    groupCount--;
                }
                groupSize *= 2;
            }
            sortingStacks.StopSort();
        }
    }
}
