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
            Debug.Log(heap[0].stack);
            // while (heap.Count > 0)
            // {
                bool sortingHeap = true;
                while (sortingHeap)
                {
                    bool noSwaps = true;
                    for (int i = 0; i < heap.Count; i++)
                    {
                        // Debug.Log(i);
                        Node currentNode = heap[i];
                        if (currentNode.childA != null && currentNode.stack < currentNode.childA.stack)
                        {
                            Debug.Log(currentNode.stack + " is less than " + currentNode.childA.stack);
                            noSwaps = false;
                            HeapSwap(currentNode, currentNode.childA);
                            yield return new WaitForSeconds(sortDelay);
                            continue;
                        }
                        if (currentNode.childB != null && currentNode.stack < currentNode.childB.stack)
                        {
                            Debug.Log(currentNode.stack + " is less than " + currentNode.childB.stack);
                            noSwaps = false;
                            HeapSwap(currentNode, currentNode.childB);
                            yield return new WaitForSeconds(sortDelay);
                            continue;
                        }
                    }
                    if (noSwaps) sortingHeap = false;
                }
                // get largest node and swap with last
                // heap[0].stack;
                // heap[0] = heap[heap.Count - 1];
                // heap.Remove(heap.Count - 1);
            // }
            Debug.Log(heap[0].stack);
            sortingStacks.StopSort();
        }

        private static void HeapSwap(Node nodeA, Node nodeB)
        {
            sortingStacks.SwapStacks(nodeA.stack, nodeB.stack);
            int heapIndexA = heap.IndexOf(nodeA);
            int heapIndexB = heap.IndexOf(nodeB);
            heap[heapIndexA].stack = nodeB.stack;
            heap[heapIndexB].stack = nodeA.stack;
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
