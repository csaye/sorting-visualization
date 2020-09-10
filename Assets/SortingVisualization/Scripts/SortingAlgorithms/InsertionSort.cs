using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class InsertionSort
    {
        private static SortingStacks sortingStacks;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            int stackCount = sortingStacks.stackCount;
            for (int i = 0; i < stackCount; i++)
            {
                yield return new WaitForSeconds(sortingStacks.delay);
                int index = i;
                for (int j = i; j > 0; j--)
                {
                    if (sortingStacks.stacks[j - 1] < sortingStacks.stacks[i]) break;
                    index--;
                }
                sortingStacks.SetStack(sortingStacks.stacks[i], index);
            }
            sortingStacks.StopSort();
        }
    }
}
