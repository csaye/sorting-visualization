using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class SelectionSort
    {
        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            for (int i = 0; i < stackCount; i++)
            {
                yield return new WaitForSeconds(sortingStacks.delay);
                int smallest = int.MaxValue;
                for (int j = i; j < stackCount; j++)
                {
                    if (sortingStacks.stacks[j] < smallest) smallest = sortingStacks.stacks[j];
                }
                sortingStacks.SetStack(smallest, i);
            }
            sortingStacks.StopSort();
        }
    }
}
