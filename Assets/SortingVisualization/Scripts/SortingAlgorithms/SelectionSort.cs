using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class SelectionSort
    {
        private static SortingStacks sortingStacks;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            for (int i = 0; i < SortingStacks.stackCount; i++)
            {
                yield return new WaitForSeconds(SortingStacks.sortDelay);
                int smallest = SortingStacks.stackCount;
                for (int j = i; j < SortingStacks.stackCount; j++)
                {
                    if (sortingStacks.stacks[j] < smallest) smallest = sortingStacks.stacks[j];
                }
                sortingStacks.SetStack(smallest, i);
            }
            sortingStacks.StopSort();
        }
    }
}
