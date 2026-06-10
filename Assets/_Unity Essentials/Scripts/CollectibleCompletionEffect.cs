using UnityEngine;
using TMPro;
using System;

public class CollectibleCompletionEffect : MonoBehaviour
{
    private TextMeshProUGUI collectibleText;

    public ParticleSystem completeEffect;
    public AudioSource completeSound;

    private bool alreadyTriggered = false;

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();

        if (collectibleText == null)
        {
            Debug.LogError("CollectibleCompletionEffect requiere un componente TextMeshProUGUI en el mismo GameObject.");
            return;
        }

        UpdateCollectibleDisplay();
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(
                collectibleType,
                FindObjectsSortMode.None
            ).Length;
        }

        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(
                collectible2DType,
                FindObjectsSortMode.None
            ).Length;
        }

        collectibleText.text = $"Collectibles remaining: {totalCollectibles}";

        if (totalCollectibles == 0 && !alreadyTriggered)
        {
            alreadyTriggered = true;

            if (completeEffect != null)
                completeEffect.Play();

            if (completeSound != null)
                completeSound.Play();
        }
    }
}