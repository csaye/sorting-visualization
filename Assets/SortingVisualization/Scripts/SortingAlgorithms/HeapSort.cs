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
        private static float sortDelay = SortingStacks.sortDelay;

        private static List<Node> heap = new List<Node>();

        public static IEnumerator Sort(SortingStacks _sortingStacks)
        {
            sortingStacks = _sortingStacks;
            InitializeHeap();
            // LogHeap();
            while (heap[0].stack != 63)
            {
                Debug.Log(heap[0]);
                bool nodeSwapped = false;
                for (int i = 0; i < heap.Count; i++)
                {
                    if (heap[i].childA != null && heap[i].stack < heap[i].childA.stack)
                    {
                        nodeSwapped = true;
                        HeapSwap(heap[i], heap[i].childA);
                        yield return new WaitForSeconds(sortDelay);
                    }
                    if (heap[i].childB != null && heap[i].stack < heap[i].childB.stack)
                    {
                        nodeSwapped = true;
                        HeapSwap(heap[i], heap[i].childB);
                        yield return new WaitForSeconds(sortDelay);
                    }
                }
                if (!nodeSwapped) break;
            }
            // Debug.Log("done, node 63 at " + heap.FindIndex(node => node.stack == 63));
            yield return null;
            sortingStacks.StopSort();
        }

        private static void LogHeap()
        {
            foreach (Node n in heap)
            {
                Debug.Log(n.stack);
                if (n.childA != null) Debug.Log(n.childA.stack);
                if (n.childB != null) Debug.Log(n.childB.stack);
                Debug.Log("----------------------");
            }
        }

        private static void HeapSwap(Node nodeA, Node nodeB)
        {
            Debug.Log("swapping " + nodeA.stack + " and " + nodeB.stack);
            sortingStacks.SwapStacks(nodeA.stack, nodeB.stack);
            int heapIndexA = heap.IndexOf(nodeA);
            int heapIndexB = heap.IndexOf(nodeB);
            heap[heapIndexA].stack = nodeB.stack;
            heap[heapIndexB].stack = nodeA.stack;
            Node temp = heap[heapIndexA];
            heap[heapIndexA] = heap[heapIndexB];
            heap[heapIndexB] = temp;
        }

        private static void InitializeHeap()
        {
            heap = new List<Node>();
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
