using UnityEngine;

namespace SortingVisualization
{
    public class AlgorithmButtonBar : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AlgorithmButton[] algorithmButtons = null;

        public void ResetButtonColor()
        {
            foreach (AlgorithmButton button in algorithmButtons) button.SetColor(Color.white);
        }
    }
}
