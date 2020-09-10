using UnityEngine;
using UnityEngine.Audio;

namespace SortingVisualization
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AudioMixer soundMixer = null;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(int pitch)
        {
            audioSource.pitch = 1 + ((float)pitch / 64);
            audioSource.Play();
        }

        public void SetVolume(float volume)
        {
            soundMixer.SetFloat("Volume", volume);
        }
    }
}
