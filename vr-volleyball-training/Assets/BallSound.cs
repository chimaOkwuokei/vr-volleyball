using UnityEngine;
using System.Collections;

public class BallHit : MonoBehaviour
{
    public AudioClip handHitSound;
    public float soundDuration = 0.15f; // short, punchy feel (adjust if needed)

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand") && handHitSound != null)
        {
            StartCoroutine(PlayShortClip());
        }
    }

    IEnumerator PlayShortClip()
    {
        audioSource.clip = handHitSound;
        audioSource.Play();
        yield return new WaitForSeconds(soundDuration);
        audioSource.Stop();
    }
}
