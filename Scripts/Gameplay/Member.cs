using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _jumpAudioClipList;

    [SerializeField] private Sprite _idleMemberSprite;
    [SerializeField] private Sprite _runMemberSprite;
    [SerializeField] private Sprite _deadMemberSprite;
    [SerializeField] private Leader _leader;

    private AudioSource _audioSourse;
    private SpriteRenderer _spriteRenderer;
    private float _moveSpeed;

    public bool IsMemberDead { get; private set; }

    public int MaxFollowersCount;
    public int FollowersCount;
    public GameObject Neighbour;

    private void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _moveSpeed = Random.Range(50f, 80f);
        MaxFollowersCount = Random.Range(0, 2);

        StartCoroutine(Step());
    }

    public void SetNearestNeighbour(GameObject neighbour)
    {
        Neighbour = neighbour;
    }

    private void MoveToNeighbour()
    {
        _audioSourse.clip = _jumpAudioClipList[Random.RandomRange(0, 3)];
        _audioSourse.Play();

        if (Neighbour != null)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce((Neighbour.transform.position - transform.position) * _moveSpeed);
        }

        if (Vector3.Distance(_leader.gameObject.transform.position, transform.position) >= 15)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce((_leader.transform.position - transform.position) * _moveSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce((_leader.transform.position - transform.position) * _moveSpeed);
        }
    }

    private IEnumerator Step()
    {
        _spriteRenderer.sprite = _runMemberSprite;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        MoveToNeighbour();

        yield return new WaitForSeconds(Random.Range(0.3f, 0.5f));

        StartCoroutine(WaitingBeforeStep());
    }

    private IEnumerator WaitingBeforeStep()
    {
        _spriteRenderer.sprite = _idleMemberSprite;

        yield return new WaitForSeconds(Random.Range(0.1f, 0.6f));

        StartCoroutine(Step());
    }

    public void Dead()
    {
        IsMemberDead = true;

        StopAllCoroutines();

        _spriteRenderer.sprite = _deadMemberSprite;
    }
}