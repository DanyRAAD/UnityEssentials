using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;
    public AudioClip sonidoDestruccion; // <- agrega esto

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Reproducir sonido
            AudioSource.PlayClipAtPoint(
                sonidoDestruccion,
                transform.position
            );

            // Efecto de partículas
            Instantiate(
                onCollectEffect,
                transform.position,
                transform.rotation
            );

            // Destruir objeto
            Destroy(gameObject);
        }
    }
}