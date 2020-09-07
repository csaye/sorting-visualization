using System.Linq;
using UnityEngine;

namespace SortingVisualization
{
    public class SortingStacks : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform[] stackTransforms = new Transform[stackCount];
        [SerializeField] private int[] stackNumbers = new int[stackCount];

        private const int stackCount = 64;

        private void Update()
        {
            if (Input.GetKeyDown("space")) RandomizeStacks();
        }

        private void RandomizeStacks()
        {
            int[] randomIndices = GetRandomIndices(stackCount);
            for (int i = 0; i < stackCount; i++)
            {
                stackTransforms[randomIndices[i]].SetSiblingIndex(i);
            }
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
                if (stackNumbers[i] != i) return false;
            }
            return true;
        }
    }
}
