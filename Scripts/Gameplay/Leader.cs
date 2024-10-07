using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private List<AudioClip> _jumpAudioClipList;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Sprite _idleLeaderSprite;
    [SerializeField] private Sprite _RunLeaderSprite;
    [SerializeField] private Sprite _deadLeaderSprite;

    private AudioSource _audioSourse;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private bool _isRightLegForward;

    private void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveToPoint(Vector3 point)
    {
        StopAllCoroutines();

        _spriteRenderer.sprite = _RunLeaderSprite;

        if (_isRightLegForward)
        {
            _spriteRenderer.flipX = false;
            _isRightLegForward = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
            _isRightLegForward = true;
        }

        _rigidbody.AddForce((point - transform.position).normalized * _moveSpeed);

        _audioSourse.clip = _jumpAudioClipList[Random.Range(0, 3)];
        _audioSourse.Play();

        StartCoroutine(TimeBeforLeaderIdle());
    }

    private IEnumerator TimeBeforLeaderIdle()
    {
        yield return new WaitForSeconds(0.4f);
        _spriteRenderer.sprite = _idleLeaderSprite;
    }

    public void Dead()
    {
        _spriteRenderer.sprite = _deadLeaderSprite;

        StopAllCoroutines();
        StartCoroutine(TimeBeforeLeaderDead());
    }

    private IEnumerator TimeBeforeLeaderDead()
    {
        yield return new WaitForSeconds(0f);

        Time.timeScale = 0f;

        _gameOverPanel.SetActive(true);
    }
}