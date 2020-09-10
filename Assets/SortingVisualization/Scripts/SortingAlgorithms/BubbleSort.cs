using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class BubbleSort
    {
        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            while (!sortingStacks.StacksSorted())
            {
                for (int i = 1; i < stackCount; i++)
                {
                    if (sortingStacks.stacks[i] < sortingStacks.stacks[i - 1])
                    {
                        yield return new WaitForSeconds(sortingStacks.delay);
                        sortingStacks.SetStack(sortingStacks.stacks[i], i - 1);
                    }
                }
            }
            sortingStacks.StopSort();
        }
    }
}
