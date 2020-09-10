using UnityEngine;
using UnityEngine.UI;

namespace SortingVisualization
{
    [RequireComponent(typeof(Slider))]
    public class VolumeSlider : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SoundManager soundManager = null;

        private Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void UpdateVolume()
        {
            float volume = -(1000 / (slider.value + 10)) + 20;
            soundManager.SetVolume(volume);
        }
    }
}
