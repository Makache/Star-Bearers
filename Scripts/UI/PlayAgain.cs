using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void GameAgain()
    {
        SceneManager.LoadScene(0);
    }
}