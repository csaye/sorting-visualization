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
        [SerializeField] private int[] stacks = new int[stackCount];
        [SerializeField] private Transform pointerTransform = null;

        public bool sorting {get; private set;}

        private Algorithm algorithm;

        private Coroutine sortCoroutine;

        private const int stackCount = 64;

        private const float sortDelay = 4 / (float)64;

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
            for (int i = 0; i < stackCount; i++) SetStack(i, i);
        }

        public void RandomizeStacks()
        {
            int[] randomIndices = GetRandomIndices(stackCount);
            for (int i = 0; i < stackCount; i++) SetStack(randomIndices[i], i);
        }

        public void WorstCaseStacks()
        {
            for (int i = 0; i < stackCount; i++) SetStack((stackCount - 1) - i, i);
        }

        private void StartSort()
        {
            if (StacksSorted()) return;
            sorting = true;
            if (sortCoroutine != null) StopCoroutine(sortCoroutine);
            switch (algorithm)
            {
                case Algorithm.SelectionSort:
                    sortCoroutine = StartCoroutine(SelectionSort());
                    break;
                // case Algorithm.InsertionSort:
                //     sortCoroutine = StartCoroutine(InsertionSort());
            }
        }

        private void StopSort()
        {
            if (sortCoroutine != null) StopCoroutine(sortCoroutine);
            sorting = false;
        }

        private void SetStack(int stack, int index)
        {
            for (int i = Array.IndexOf(stacks, stack); i > index; i--) stacks[i] = stacks[i - 1];
            stacks[index] = stack;
            stackTransforms[stack].SetSiblingIndex(index);
            pointerTransform.position = new Vector3(stackTransforms[stack].position.x, pointerTransform.position.y, 0);
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

        private bool StacksSorted()
        {
            for (int i = 0; i < stackCount; i++)
            {
                if (stacks[i] != i) return false;
            }
            return true;
        }

        private IEnumerator SelectionSort()
        {
            for (int i = 0; i < stackCount; i++)
            {
                yield return new WaitForSeconds(sortDelay);
                int smallest = stackCount;
                for (int j = i; j < stackCount; j++)
                {
                    if (stacks[j] < smallest) smallest = stacks[j];
                }
                SetStack(smallest, i);
            }
            sorting = false;
        }
    }
}
