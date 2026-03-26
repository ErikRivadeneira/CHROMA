using System;
using System.Collections;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] private Color currentColor = Color.white;
    [SerializeField] float colorChangeTime = 0.5f;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip changeColorClip;

    private void OnEnable()
    {
        ColorContainer.ColorChanged += ExchangeColor;
        ColoredSwitch.IsTheSameColor += CheckColors;
    }
    private void OnDisable()
    {
        ColorContainer.ColorChanged -= ExchangeColor;
        ColoredSwitch.IsTheSameColor -= CheckColors;
    }

    private void Start()
    {
        sr.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
    }

    private Color ExchangeColor(Color newColor)
    {
        Color oldColor = currentColor;
        newColor.a = 1f;
        currentColor.a = 1f; 
        StartCoroutine(ChangeColor(newColor));
        aSource.PlayOneShot(changeColorClip);
        return oldColor;
    }

    public Color GetColor()
    {
        return currentColor;
    }

    private bool CheckColors(Color otherColor)
    {
        return otherColor == currentColor;
    }

    IEnumerator ChangeColor(Vector4 targetColor)
    {
        float timer = 0f;
        Vector4 startColor = currentColor;
        while (timer <= colorChangeTime)
        {
            currentColor = Vector4.Lerp(startColor, targetColor, timer);
            sr.color = currentColor;
            timer += Time.deltaTime;
            yield return null;
        }
        currentColor = targetColor;
        sr.color = currentColor;
        yield return null;
    }
}
