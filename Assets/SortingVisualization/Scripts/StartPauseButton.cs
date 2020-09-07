using TMPro;
using UnityEngine;

namespace SortingVisualization
{
    public class StartPauseButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI textField = null;
        [SerializeField] private SortingStacks sortingStacks = null;

        public void OnClick()
        {
            sortingStacks.TriggerSorting();
        }

        private void Update()
        {
            textField.text = sortingStacks.sorting ? "Pause" : "Start";
        }
    }
}
