using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class ShellSort
    {
        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;
        private static float sortDelay = SortingStacks.sortDelay;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            int[] stacks = sortingStacks.stacks;
            int gap = stackCount / 2;
            while (gap > 1)
            {
                for (int i = 0; i < gap; i++)
                {
                    for (int j = i; j + gap < stackCount; j += gap)
                    {
                        int smallest = int.MaxValue;
                        for (int k = j; k + gap < stackCount; k += gap)
                        {
                            if (stacks[k] < smallest) smallest = stacks[k];
                        }
                        sortingStacks.SetStack(smallest, j);
                        yield return new WaitForSeconds(sortDelay);
                    }
                }
                gap /= 2;
            }
            yield return null;
            sortingStacks.StopSort();
        }
    }
}
