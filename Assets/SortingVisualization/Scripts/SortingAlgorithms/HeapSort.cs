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
            LogHeap();
            yield return null;
            sortingStacks.StopSort();
        }

        private static void LogHeap()
        {
            foreach (Node n in heap)
            {
                if (n == null) { Debug.Log("null node"); continue;}
                Debug.Log(n.stack);
                if (n.childA == null) Debug.Log("null child a");
                    else Debug.Log(n.childA.stack);
                if (n.childB == null) Debug.Log("null child b");
                    else Debug.Log(n.childB.stack);
                Debug.Log("--------------------------------------------------");
            }
        }

        private static Node[] GetInitialHeap()
        {
            Node[] initialHeap = new Node[stackCount];
            for (int i = 0; i < stackCount; i++)
            {
                int stackToAdd = sortingStacks.stacks[i];
                Node nodeToAdd = new Node(stackToAdd);
                for (int j = 0; j < stackCount; j++)
                {
                    if (initialHeap[j] == null)
                    {
                        initialHeap[j] = nodeToAdd;
                        break;
                    }
                    if (initialHeap[j].childA == null)
                    {
                        initialHeap[j].childA = nodeToAdd;
                        for (int k = j; k < stackCount; k++)
                        {
                            if (initialHeap[k] == null)
                            {
                                initialHeap[k] = nodeToAdd;
                                break;
                            }
                        }
                        break;
                    }
                    if (initialHeap[j].childB == null)
                    {
                        initialHeap[j].childB = nodeToAdd;
                        for (int k = j; k < stackCount; k++)
                        {
                            if (initialHeap[k] == null)
                            {
                                initialHeap[k] = nodeToAdd;
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
