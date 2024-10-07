using UnityEngine;

public class ThornyPlant : MonoBehaviour
{
    [SerializeField] private AudioClip _damageClip;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _damageClip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Member>())
        {
            if (collision.GetComponent<Member>().IsMemberDead) return;

            collision.GetComponent<Member>().Dead();

            _audioSource.Play();
        }
        else if (collision.GetComponent<Leader>())
        {
            _audioSource.Play();

            collision.GetComponent<Leader>().Dead();
        }
    }
}