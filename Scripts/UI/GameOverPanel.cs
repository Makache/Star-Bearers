using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private ScreenTransition _screenTransition;

    public void TryAgain()
    {
        Time.timeScale = 1f;
        _screenTransition.StartFadeIn(0);
    }
}