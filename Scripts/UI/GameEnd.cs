using TMPro;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private ScreenTransition _screenTransition;
    [SerializeField] private float _maxMembersCount;
    [SerializeField] private TMP_Text _membersCountText;
    private float _membersCount = 0;

    private void FixedUpdate()
    {
        if (_membersCount >= _maxMembersCount)
        {
            _screenTransition.StartFadeIn(1);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Member>())
        {
            _membersCount++;
            _membersCountText.text = $"{_membersCount}/{_maxMembersCount}";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Member>())
        {
            _membersCount--;
            _membersCountText.text = $"{_membersCount}/{_maxMembersCount}";
        }
    }
}
