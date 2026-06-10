using UnityEngine;

public class BlockImpactSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float minImpactForce = 1f;

    private float lastPlayTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minImpactForce)
        {
            if (Time.time - lastPlayTime > 0.1f)
            {
                audioSource.Play();
                lastPlayTime = Time.time;
            }
        }
    }
}