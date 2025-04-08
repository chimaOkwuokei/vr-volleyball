using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioClip bounceSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (bounceSound != null)
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }
}
