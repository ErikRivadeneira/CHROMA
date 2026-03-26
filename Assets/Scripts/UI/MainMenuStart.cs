using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour
{
    [SerializeField] private InputManagerSO inputManager;
    public static event Action StartGame;

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
        StartGame?.Invoke();
    }
}
