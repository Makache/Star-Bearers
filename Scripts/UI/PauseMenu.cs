using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;

    public bool IsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Switch();
        }
    }

    public void Switch()
    {
        if (IsPaused)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        _pauseMenuPanel.SetActive(true);
    }

    private void Close()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        _pauseMenuPanel.SetActive(false);
    }
}