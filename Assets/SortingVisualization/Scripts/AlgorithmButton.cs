using UnityEngine;
using UnityEngine.UI;

namespace SortingVisualization
{
    public enum Algorithm
    {
        SelectionSort,
        InsertionSort,
        BubbleSort,
        QuickSort
    }
    
    [RequireComponent(typeof(Button), typeof(Image))]
    public class AlgorithmButton : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private Algorithm algorithm = new Algorithm();

        [Header("References")]
        [SerializeField] private SortingStacks sortingStacks = null;
        [SerializeField] private AlgorithmButtonBar algorithmButtonBar = null;

        private Button button;
        private Image image;

        private Color lightBlue;

        private void Start()
        {
            button = GetComponent<Button>();
            image = GetComponent<Image>();

            lightBlue = new Color(0.7f, 0.7f, 0.8f, 1);
        }

        public void SetAlgorithm()
        {
            algorithmButtonBar.ResetButtonColor();
            SetColor(lightBlue);
            sortingStacks.SetAlgorithm(algorithm);
        }

        public void SetColor(Color color)
        {
            image.color = color;
        }
        
        private void Update()
        {
            button.interactable = !sortingStacks.sorting;
        }
    }
}
