using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class HeapSort
    {
        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            int[] stacks = sortingStacks.stacks;
            for (int i = (stackCount / 2) - 1; i >= 0; i--)
            {
                bool sorting = true;
                int index = i;
                while (sorting)
                {
                    int largest = index;
                    int left = (2 * index) + 1;
                    int right = (2 * index) + 2;
                    if (left < stackCount && stacks[left] > stacks[largest]) largest = left;
                    if (right < stackCount && stacks[right] > stacks[largest]) largest = right;
                    if (largest != index)
                    {
                        sortingStacks.SwapStackIndices(index, largest);
                        yield return new WaitForSeconds(sortingStacks.delay);
                        index = largest;
                    }
                    else sorting = false;
                }
            }
            for (int i = stackCount - 1; i > 0; i--)
            {
                sortingStacks.SwapStackIndices(0, i);
                yield return new WaitForSeconds(sortingStacks.delay);
                bool sorting = true;
                int index = 0;
                while (sorting)
                {
                    int largest = index;
                    int left = (2 * index) + 1;
                    int right = (2 * index) + 2;
                    if (left < i && stacks[left] > stacks[largest]) largest = left;
                    if (right < i && stacks[right] > stacks[largest]) largest = right;
                    if (largest != index)
                    {
                        sortingStacks.SwapStackIndices(index, largest);
                        yield return new WaitForSeconds(sortingStacks.delay);
                        index = largest;
                    }
                    else sorting = false;
                }
            }
            sortingStacks.StopSort();
        }
    }
}
