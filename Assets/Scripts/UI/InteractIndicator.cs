using System;
using UnityEngine;

public class InteractIndicator : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private void OnEnable()
    {
        PlayerInteract.CanInteract += ShowInteract;
    }
    private void OnDisable()
    {
        PlayerInteract.CanInteract -= ShowInteract;
    }

    private void ShowInteract(bool canInteract)
    {
        if (canInteract)
            canvasGroup.alpha = 1.0f;
        else
            canvasGroup.alpha = 0.0f;
    }
}
