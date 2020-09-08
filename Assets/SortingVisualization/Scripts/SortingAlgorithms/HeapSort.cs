using System.Collections;
using UnityEngine;

namespace SortingVisualization
{
    public class HeapSort
    {
        private class Node
        {
            public Node(int stack_) { stack = stack_; }
            public int stack = -1;
            public Node childA = null;
            public Node childB = null;
        }

        private static SortingStacks sortingStacks;

        private static int stackCount = SortingStacks.stackCount;
        // private static float sortDelay = SortingStacks.sortDelay;

        private static Node[] heap = new Node[stackCount];

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            heap = GetInitialHeap();
            yield return null;
            sortingStacks.StopSort();
        }

        private static Node[] GetInitialHeap()
        {
            Node[] initialHeap = new Node[stackCount];
            for (int i = 0; i < stackCount; i++)
            {
                int stackToAdd = sortingStacks.stacks[i];
                Node nodetoAdd = new Node(stackToAdd);
                for (int j = 0; j < stackCount; j++)
                {
                    if (initialHeap[j] == null)
                    {
                        initialHeap[j] = nodetoAdd;
                        break;
                    }
                    if (initialHeap[j].childA == null)
                    {
                        initialHeap[j].childA = nodetoAdd;
                        for (int k = j; k < stackToAdd; k++)
                        {
                            if (initialHeap[k] == null)
                            {
                                initialHeap[k] = nodetoAdd;
                                break;
                            }
                        }
                        break;
                    }
                    if (initialHeap[j].childB == null)
                    {
                        initialHeap[j].childB = nodetoAdd;
                        for (int k = j; k < stackToAdd; k++)
                        {
                            if (initialHeap[k] == null)
                            {
                                initialHeap[k] = nodetoAdd;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return initialHeap;
        }
    }
}
