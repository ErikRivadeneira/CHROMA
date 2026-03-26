using System;
using System.Collections;
using UnityEngine;

public class ColorContainer : MonoBehaviour, IInteractuable
{
    [Header("Func Related")]
    [SerializeField] private Color color;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float colorChangeTime = 0.5f;

    [Header("Animation Related")]
    [SerializeField] private Animator animator;
    [SerializeField] private float timeBetweenBlinks = 2.5f;
    [SerializeField] private float timeVariation = 0.5f;


    public static event Func<Color, Color> ColorChanged;

    private void Start()
    {
        sr.color = new Color(color.r,color.g,color.b,1f);
        PlayBlink();
    }

    public void Interact()
    {
        Color exchangedColor = (Color)(ColorChanged?.Invoke(color));
        color.a = 1f;
        exchangedColor.a = 1f;
        StartCoroutine(ChangeColor(exchangedColor));
        color = exchangedColor;
    }
    IEnumerator ChangeColor(Vector4 targetColor)
    {
        float timer = 0f;
        Vector4 startColor = color;
        while (timer <= colorChangeTime)
        {
            sr.color = Vector4.Lerp(startColor, targetColor, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        sr.color = targetColor;
        yield return null;
    }

    void PlayBlink()
    {
        animator.Play("Blink");
        float addedTime = UnityEngine.Random.Range(-timeVariation, timeVariation);
        float nextBlink = timeBetweenBlinks + addedTime;
        Invoke(nameof(PlayBlink), nextBlink);
    }
}
