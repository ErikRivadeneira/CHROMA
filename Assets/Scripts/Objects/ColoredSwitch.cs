using System;
using UnityEngine;

public class ColoredSwitch : MonoBehaviour, IInteractuable
{
    [SerializeField] private Color color = Color.white;
    [SerializeField] private ESizes switchTargetSize = ESizes.medium;
    [SerializeField] private SpriteRenderer sr;

    public static event Action<ESizes> SwitchSizeConversionCallback;
    public static event Func<Color, bool> IsTheSameColor;

    private void Start()
    {
        sr.color = new Color(color.r, color.g, color.b, 1f);
    }

    void IInteractuable.Interact()
    {
        bool isSameColor = (bool)(IsTheSameColor?.Invoke(color));
        if (isSameColor)
        {
            SwitchSizeConversionCallback?.Invoke(switchTargetSize);
        }
    }
}
