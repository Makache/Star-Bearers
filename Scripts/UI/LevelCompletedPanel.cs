using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedPanel : MonoBehaviour
{
    [SerializeField] private ScreenTransition _screenTransition;

    public void Replay()
    {
        Time.timeScale = 1f;
        _screenTransition.StartFadeIn(0);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        _screenTransition.StartFadeIn(1);
    }
}