using UnityEngine;

namespace SortingVisualization
{
    public class StacksButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SortingStacks sortingStacks = null;

        public void ResetStacks()
        {
            sortingStacks.ResetStacks();
        }

        public void RandomizeStacks()
        {
            sortingStacks.RandomizeStacks();
        }

        public void WorstCaseStacks()
        {
            sortingStacks.WorstCaseStacks();
        }
    }
}
