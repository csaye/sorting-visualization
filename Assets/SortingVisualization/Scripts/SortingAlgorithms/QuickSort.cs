using System.Collections;

namespace SortingVisualization
{
    public class QuickSort
    {
        private static SortingStacks sortingStacks;

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            // int pivot = GetPivot(stacks, 0, stackCount);
            yield return null;
            sortingStacks.StopSort();
        }

        // private void GetPivot()
        // {

        // }
    }
}
