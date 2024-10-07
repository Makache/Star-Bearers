using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSlides : MonoBehaviour
{
    [SerializeField] private GameObject _continueButton;
    [SerializeField] private List<GameObject> _slides;

    private int _currentSlideIndex = 0;

    public void Continue()
    {
        if (_currentSlideIndex < _slides.Count - 2)
        {
            _currentSlideIndex++;
            _slides[_currentSlideIndex - 1].SetActive(false);
            _slides[_currentSlideIndex].SetActive(true);
        }
        else
        {
            _slides[_slides.Count - 1].SetActive(true);
            _continueButton.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}