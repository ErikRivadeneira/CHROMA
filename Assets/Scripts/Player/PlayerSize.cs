using System.Collections;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    [SerializeField] private ESizes currentSize = ESizes.medium;
    [SerializeField] private float sizeChangeTime = 0.5f;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip growClip;
    [SerializeField] private AudioClip shrinkClip;

    private void OnEnable()
    {
        ColoredSwitch.SwitchSizeConversionCallback += SwitchSize;
    }
    private void OnDisable()
    {
        ColoredSwitch.SwitchSizeConversionCallback -= SwitchSize;
    }

    void Start()
    {
        SwitchSize(currentSize);
    }

    void SwitchSize(ESizes newSize)
    {
        switch (newSize)
        {
            case ESizes.small:
                StartCoroutine(ChangeSize(new Vector3(0.5f, 0.5f, 1f)));
                break;
            case ESizes.medium:
                StartCoroutine(ChangeSize(new Vector3(1.5f, 1.5f, 1f)));
                break;
            case ESizes.large:
                StartCoroutine(ChangeSize(new Vector3(3f, 3f, 1f)));
                break;
            default:
                this.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
                break;
        }

        if (newSize > currentSize)
        {
            aSource.PlayOneShot(growClip);
        }
        else
        {
            aSource.PlayOneShot(shrinkClip);
        }
            currentSize = newSize;
    }

    public ESizes GetSize()
    {
        return currentSize;
    }
    IEnumerator ChangeSize(Vector3 targetSize)
    {
        float timer = 0f;
        Vector4 startSize = transform.localScale;
        while (timer < sizeChangeTime)
        {
            transform.localScale = Vector3.Lerp(startSize, targetSize, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetSize;
        yield return null;
    }
}
