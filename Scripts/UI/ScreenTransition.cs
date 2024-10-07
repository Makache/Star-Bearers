using System.Collections;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private RectTransform _fadeInTransform;
    [SerializeField] private RectTransform _fadeOutTransform;

    private float _topFadeInValue;
    private float _bottomFadeOutValue;

    public bool IsFadeIn;
    public bool IsFadeOut;

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    public void StartFadeIn(int transitionChange)
    {
        if (transitionChange == 0)
        {
            StartCoroutine(FadeIn(0));
        }
        else
        {
            StartCoroutine(FadeIn(1));
        }
    }

    private IEnumerator FadeIn(int transition)
    {
        IsFadeIn = false;
        _fadeInTransform.gameObject.SetActive(true);

        for (float i = -4100f; i <= 1000f; i += 100)
        {
            _topFadeInValue = i;
            _fadeInTransform.offsetMax = new Vector2(_fadeInTransform.offsetMax.x, _topFadeInValue);
            yield return new WaitForSeconds(0.01f);
        }

        if (transition == 0)
        {
            _sceneLoader.Replay();
        }
        else
        {
            _sceneLoader.Continue();
        }
    }

    private IEnumerator FadeOut()
    {
        IsFadeOut = false;
        _fadeOutTransform.gameObject.SetActive(true);

        for (float i = -1000f; i <= 4100f; i += 100)
        {
            _bottomFadeOutValue = i;
            _fadeOutTransform.offsetMin = new Vector2(_fadeOutTransform.offsetMin.x, _bottomFadeOutValue);
            yield return new WaitForSeconds(0.01f);
        }

        _fadeOutTransform.gameObject.SetActive(false);
    }
}