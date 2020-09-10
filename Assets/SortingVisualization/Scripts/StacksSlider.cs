using UnityEngine;
using UnityEngine.UI;

namespace SortingVisualization
{
    [RequireComponent(typeof(Slider))]
    public class StacksSlider : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SortingStacks sortingStacks = null;

        private Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void UpdateStacks()
        {
            sortingStacks.SetStackCount(Mathf.RoundToInt(slider.value));
        }

        private void Update()
        {
            slider.interactable = !sortingStacks.sorting;
        }
    }
}
