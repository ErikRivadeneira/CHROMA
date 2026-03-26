using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class EndToMenu : MonoBehaviour
{
    [SerializeField] private InputManagerSO inputManager;
    public static event Action ToMainMenu;

    private void OnEnable()
    {
        inputManager.OnStart += StartButtonWasPressed;
    }
    private void OnDisable()
    {
        inputManager.OnStart -= StartButtonWasPressed;
    }
    private void StartButtonWasPressed()
    {
        ToMainMenu?.Invoke();
    }
}
