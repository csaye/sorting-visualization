using TMPro;
using UnityEngine;

namespace SortingVisualization
{
    public class StartStopButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI textField = null;
        [SerializeField] private SortingStacks sortingStacks = null;

        public void TriggerSorting()
        {
            sortingStacks.TriggerSorting();
        }

        private void Update()
        {
            textField.text = sortingStacks.sorting ? "Stop" : "Start";
        }
    }
}
