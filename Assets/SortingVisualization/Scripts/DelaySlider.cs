using UnityEngine;
using UnityEngine.UI;

namespace SortingVisualization
{
    [RequireComponent(typeof(Slider))]
    public class DelaySlider : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SortingStacks sortingStacks = null;

        private Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void UpdateDelay()
        {
            sortingStacks.SetDelay(0.125f - slider.value);
        }
    }
}
