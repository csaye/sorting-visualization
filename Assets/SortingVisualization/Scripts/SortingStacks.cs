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

        public bool sorting {get; private set;}

        private Algorithm algorithm;

        private Coroutine sortCoroutine;

        private const int stackCount = 64;

        private const float stepDelay = 0.5f;

        public void TriggerSorting()
        {
            if (sorting) PauseSort(); else StartSort();
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
            sorting = true;
            if (sortCoroutine != null) StopCoroutine(sortCoroutine);
            sortCoroutine = StartCoroutine(Sort());
        }

        private void PauseSort()
        {
            if (sortCoroutine != null) StopCoroutine(sortCoroutine);
            sorting = false;
        }

        private void SetStack(int stack, int index)
        {
            stackTransforms[stack].SetSiblingIndex(index);
        }

        private int[] GetRandomIndices(int size)
        {
            int[] randomIndices = new int[size];
            for (int i = 0; i < size; i++) randomIndices[i] = -1;
            for (int i = 0; i < size; i++)
            {
                int randomIndex = Random.Range(0, size);
                while (randomIndices.Contains(randomIndex)) randomIndex = Random.Range(0, size);
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

        private IEnumerator Sort()
        {
            while (!StacksSorted())
            {
                yield return new WaitForSeconds(stepDelay);
                switch (algorithm)
                {
                    case Algorithm.SelectionSort:
                    {
                        int[] nextSet = SelectionSort.GetNextStackSet(stacks);
                        SetStack(nextSet[0], nextSet[1]);
                        break;
                    }
                    case Algorithm.InsertionSort:
                    {
                        int[] nextSet = InsertionSort.GetNextStackSet(stacks);
                        SetStack(nextSet[0], nextSet[1]);
                        break;
                    }
                }
            }
            sorting = false;
        }
    }
}
