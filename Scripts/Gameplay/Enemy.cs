using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _punchAudioClipList;

    [SerializeField] private Sprite _idleEnemySprite;
    [SerializeField] private Sprite _enemyPunchSpite;

    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Member>())
        {
            if (collision.GetComponent<Member>().IsMemberDead) return;

            Vector2 direction = collision.transform.position - transform.position;

            if (direction.x <= 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }

            collision.GetComponent<Member>().Dead();

            StartCoroutine(PunchTime());
        }
        else if (collision.GetComponent<Leader>())
        {
            Vector2 direction = collision.transform.position - transform.position;

            if (direction.x <= 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }

            collision.GetComponent<Leader>().Dead();

            StartCoroutine(PunchTime());
        }
    }

    private IEnumerator PunchTime()
    {
        _spriteRenderer.sprite = _enemyPunchSpite;

        _audioSource.clip = _punchAudioClipList[Random.Range(0, 3)];
        _audioSource.Play();

        yield return new WaitForSeconds(0.5f);

        _spriteRenderer.sprite = _idleEnemySprite;
    }
}