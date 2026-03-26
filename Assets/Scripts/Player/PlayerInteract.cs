using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private InputManagerSO inputManager;
    private IInteractuable interactuable;
    private bool playerCanInteract = true;

    public static event Action<bool> CanInteract;

    private void OnEnable()
    {
        inputManager.OnInteract += Interact;
    }

    private void OnDisable()
    {
        inputManager.OnInteract -= Interact;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractuable IObject = collision.gameObject.GetComponent<IInteractuable>();
        if (IObject != null)
        {
            interactuable = (IInteractuable)IObject;
            CanInteract?.Invoke(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactuable = null;
        CanInteract?.Invoke(false);
    }

    void Interact()
    {
        if (interactuable != null && playerCanInteract)
        {
            interactuable.Interact();
            playerCanInteract = false;
            Invoke(nameof(ResetInteract), 1f);
        }
    }

    private void ResetInteract()
    {
        playerCanInteract = true;
    }
}
