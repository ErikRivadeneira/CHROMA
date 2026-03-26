using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPulse : MonoBehaviour
{
    [SerializeField] float pulseRate = 1f;
    [SerializeField] float maxIntensity = 5.5f;
    [SerializeField] float minIntensity = 3.5f;
    private Light2D l2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        l2d = GetComponent<Light2D>();
        StartCoroutine(PulseDecrement());
    }

    IEnumerator PulseIncrement()
    {
        float currentI = l2d.intensity;
        while(currentI < maxIntensity)
        {

            currentI += Time.deltaTime * pulseRate;
            l2d.intensity = currentI;
            yield return null;
        }
        StartCoroutine(PulseDecrement());
    }

    IEnumerator PulseDecrement()
    {
        float currentI = l2d.intensity;
        while (currentI > minIntensity)
        {

            currentI -= Time.deltaTime * pulseRate;
            l2d.intensity = currentI;
            yield return null;
        }
        StartCoroutine(PulseIncrement());
    }
}
