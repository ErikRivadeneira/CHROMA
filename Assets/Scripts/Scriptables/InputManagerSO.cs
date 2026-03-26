using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputManagerSO", menuName = "Scriptable Objects/Input/InputManagerSO")]
public class InputManagerSO : ScriptableObject
{
    InputSystem_Actions input;

    public event Action<Vector2> OnMove;
    public event Action OnInteract;
    public event Action OnPause;
    public event Action OnStart;

    private void OnEnable()
    {
        input = new InputSystem_Actions();
        input.Player.Enable();
        input.Player.Move.started += Move;
        input.Player.Move.performed += Move;
        input.Player.Move.canceled += Move;
        input.Player.Interact.started += Interact;
        input.Player.Pause.started += Pause;
        input.Player.Start.started += StartGame;
    }
     
    private void OnDisable()
    {
        input.Player.Disable();
    }

    private void StartGame(InputAction.CallbackContext ctx)
    {
        OnStart?.Invoke();
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        OnMove?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        OnInteract?.Invoke();
    }

    private void Pause(InputAction.CallbackContext ctx)
    {
        OnPause?.Invoke();
    }
}
