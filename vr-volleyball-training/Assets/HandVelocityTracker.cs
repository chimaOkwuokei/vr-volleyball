
using UnityEngine;

public class HandVelocityTracker : MonoBehaviour
{
    public Vector3 Velocity { get; private set; }
    private Vector3 lastPosition;

    void Update()
    {
        Velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}
