using UnityEngine;
using System.Collections;

public class BallSound : MonoBehaviour
{
    public AudioClip bounceSound;
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.3f)
        {
            audioSrc.PlayOneShot(bounceSound);
        }
    }
}
