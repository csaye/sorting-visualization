using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace SortingVisualization
{
    public class SortingStacks : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform[] stackTransforms = new Transform[stackCount];
        [SerializeField] public int[] stacks = new int[stackCount];
        [SerializeField] private Transform pointerTransform = null;

        public bool sorting {get; private set;}

        private Algorithm algorithm;

        private Coroutine sortCoroutine;

        public const int stackCount = 64;

        public const float sortDelay = 8 / (float)64;

        private Vector3 pointerPosition;

        private void Start()
        {
            pointerPosition = pointerTransform.position;
        }

        public void TriggerSorting()
        {
            if (sorting) StopSort(); else StartSort();
        }

        public void SetAlgorithm(Algorithm _algorithm)
        {
            algorithm = _algorithm;
        }

        public void ResetStacks()
        {
            StopSort();
            for (int i = 0; i < stackCount; i++) SetStack(i, i);
            pointerTransform.position = pointerPosition;
        }

        public void RandomizeStacks()
        {
            StopSort();
            int[] randomIndices = GetRandomIndices(stackCount);
            for (int i = 0; i < stackCount; i++) SetStack(randomIndices[i], i);
            pointerTransform.position = pointerPosition;
        }

        public void WorstCaseStacks()
        {
            StopSort();
            for (int i = 0; i < stackCount; i++) SetStack((stackCount - 1) - i, i);
            pointerTransform.position = pointerPosition;
        }

        private void StartSort()
        {
            if (StacksSorted()) return;
            sorting = true;
            if (sortCoroutine != null) StopCoroutine(sortCoroutine);
            switch (algorithm)
            {
                case Algorithm.SelectionSort:
                    sortCoroutine = StartCoroutine(SelectionSort.Sort(this));
                    break;
                case Algorithm.InsertionSort:
                    sortCoroutine = StartCoroutine(InsertionSort.Sort(this));
                    break;
                case Algorithm.BubbleSort:
                    sortCoroutine = StartCoroutine(BubbleSort.Sort(this));
                    break;
                case Algorithm.QuickSort:
                    sortCoroutine = StartCoroutine(QuickSort.Sort(this));
                    break;
                case Algorithm.MergeSort:
                    sortCoroutine = StartCoroutine(MergeSort.Sort(this));
                    break;
                case Algorithm.HeapSort:
                    sortCoroutine = StartCoroutine(HeapSort.Sort(this));
                    break;
                case Algorithm.RadixSort:
                    sortCoroutine = StartCoroutine(RadixSort.Sort(this));
                    break;
                case Algorithm.ShellSort:
                    sortCoroutine = StartCoroutine(ShellSort.Sort(this));
                    break;
            }
        }

        public void StopSort()
        {
            if (sortCoroutine != null) StopCoroutine(sortCoroutine);
            sorting = false;
        }

        public void SetStack(int stack, int index)
        {
            if (index < Array.IndexOf(stacks, stack))
            {
                for (int i = Array.IndexOf(stacks, stack); i > index; i--) stacks[i] = stacks[i - 1];
                stacks[index] = stack;
            }
            else
            {
                for (int i = Array.IndexOf(stacks, stack); i < index; i++) stacks[i] = stacks[i + 1];
                stacks[index] = stack;
            }
            stackTransforms[stack].SetSiblingIndex(index);
            pointerTransform.position = new Vector3(stackTransforms[stack].position.x, pointerPosition.y, pointerPosition.z);
        }

        public void SwapStackIndices(int indexA, int indexB)
        {
            int temp = stacks[indexA];
            stacks[indexA] = stacks[indexB];
            stacks[indexB] = temp;
            Transform updatedTransform;
            if (indexA < indexB)
            {
                transform.GetChild(indexA).SetSiblingIndex(indexB);
                transform.GetChild(indexB - 1).SetSiblingIndex(indexA);
                updatedTransform = transform.GetChild(indexA);
            }
            else
            {
                transform.GetChild(indexB).SetSiblingIndex(indexA);
                transform.GetChild(indexA - 1).SetSiblingIndex(indexB);
                updatedTransform = transform.GetChild(indexB);
            }
            pointerTransform.position = new Vector3(updatedTransform.position.x, pointerPosition.y, pointerPosition.z);
        }

        public void SwapStacks(int stackA, int stackB)
        {
            int indexA = Array.IndexOf(stacks, stackA);
            int indexB = Array.IndexOf(stacks, stackB);
            SwapStackIndices(indexA, indexB);
        }

        private IEnumerator SwapIndices(int indexA, int indexB)
        {
            transform.GetChild(indexA).SetSiblingIndex(indexB);
            yield return new WaitForSeconds(0.1f);
            transform.GetChild(indexB - 1).SetSiblingIndex(indexA);
        }

        private int[] GetRandomIndices(int size)
        {
            int[] randomIndices = new int[size];
            for (int i = 0; i < size; i++) randomIndices[i] = -1;
            for (int i = 0; i < size; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, size);
                while (randomIndices.Contains(randomIndex)) randomIndex = UnityEngine.Random.Range(0, size);
                randomIndices[i] = randomIndex;
            }
            return randomIndices;
        }

        public bool StacksSorted()
        {
            for (int i = 0; i < stackCount; i++)
            {
                if (stacks[i] != i) return false;
            }
            return true;
        }
    }
}
