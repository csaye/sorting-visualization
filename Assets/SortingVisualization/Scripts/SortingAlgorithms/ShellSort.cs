using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class ShellSort
    {
        private static SortingStacks sortingStacks;

        // private static int stackCount = SortingStacks.stackCount;
        // private static float sortDelay = SortingStacks.sortDelay;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            yield return null;
            sortingStacks.StopSort();
        }
    }
}
