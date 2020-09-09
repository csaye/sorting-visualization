using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class RadixSort
    {
        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;
        private static float sortDelay = SortingStacks.sortDelay;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            int[] stacks = sortingStacks.stacks;
            int comparisonDigit = 1;
            while (comparisonDigit < stackCount)
            {
                int digit;
                for (int i = 0; i < stackCount; i++)
                {
                    int smallestDigit = 10;
                    int index = i;
                    for (int j = i; j < stackCount; j++)
                    {
                        digit = stacks[j] < comparisonDigit ? 0 : (stacks[j] / comparisonDigit) % 10;
                        if (digit < smallestDigit)
                        {
                            smallestDigit = digit;
                            index = j;
                        }
                    }
                    if (index != i)
                    {
                        sortingStacks.SetStack(stacks[index], i);
                        yield return new WaitForSeconds(sortDelay);
                    }
                }
                comparisonDigit *= 10;
            }
            sortingStacks.StopSort();
        }
    }
}
