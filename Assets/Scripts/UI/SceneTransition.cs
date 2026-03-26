using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float animationSpeed = 4f;

    private void OnEnable()
    {
        MainMenuStart.StartGame += LoadNextLevel;
        LevelEndTrigger.OnLevelEnd += LoadNextLevel;
        EndToMenu.ToMainMenu += LoadMenu;
    }
    private void OnDisable()
    {
        MainMenuStart.StartGame -= LoadNextLevel;
        LevelEndTrigger.OnLevelEnd -= LoadNextLevel;
        EndToMenu.ToMainMenu -= LoadMenu;
    }
    private void Start()
    {
        StartCoroutine(StartAnimation());
    }

    private void LoadNextLevel()
    {
        StartCoroutine(ExitAnimation());
    }

    private void LoadMenu()
    {
        StartCoroutine(ExitToMenu());
    }

    IEnumerator ExitAnimation()
    {
        float alpha = 0.0f;
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime * animationSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }

    IEnumerator ExitToMenu()
    {
        float alpha = 0.0f;
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime * animationSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }
        SceneManager.LoadScene(0);
        yield return null;
    }

    IEnumerator StartAnimation()
    {
        float alpha = 1.0f;
        while (alpha > 0.0f)
        {
            alpha -= Time.deltaTime * animationSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }
        yield return null;
    }
}
