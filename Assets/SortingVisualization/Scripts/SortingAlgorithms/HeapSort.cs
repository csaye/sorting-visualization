using System.Collections;
using System.Collections.Generic;
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

        private static List<Node> heap = new List<Node>();

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            InitializeHeap();
            yield return null;
            sortingStacks.StopSort();
        }

        private static void InitializeHeap()
        {
            for (int i = 0; i < stackCount; i++)
            {
                int stackToAdd = sortingStacks.stacks[i];
                Node nodeToAdd = new Node(stackToAdd);
                for (int j = 0; j < stackCount; j++)
                {
                    if (heap.Count <= j)
                    {
                        heap.Add(nodeToAdd);
                        break;
                    }
                    if (heap[j].childA == null)
                    {
                        heap[j].childA = nodeToAdd;
                        heap.Add(nodeToAdd);
                        break;
                    }
                    if (heap[j].childB == null)
                    {
                        heap[j].childB = nodeToAdd;
                        heap.Add(nodeToAdd);
                        break;
                    }
                }
            }
        }
    }
}
