using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishSpace : MonoBehaviour
{
    [SerializeField] private float _maxMembersCount;
    [SerializeField] private TMP_Text _membersCountText;
    [SerializeField] private GameObject _levelComletedPanel;
    [SerializeField] private GameObject _pauseMenuPanel;
    private float _membersCount = 0;

    private void FixedUpdate()
    {
        if (_membersCount >= _maxMembersCount)
        {
            _levelComletedPanel.SetActive(true);
            _pauseMenuPanel.SetActive(false);
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