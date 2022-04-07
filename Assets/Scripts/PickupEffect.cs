using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PickupEffect : MonoBehaviour
{

    [SerializeField] private float newBloomValue = 10f;
    [SerializeField] private float bloomDuration = 2f;

    private Volume postProcessingVolume;
    private Bloom bloom;
    private bool beginRamp;
    private float remainingBloomTime = 2f;

    void Start()
    {
        postProcessingVolume = GameObject.Find("PostProcessingVolume").GetComponent<Volume>();
        postProcessingVolume.profile.TryGet<Bloom>(out bloom);
    }

    void Update()
    {
        if (beginRamp)
        {
            RampBloomDown();
        }
    }

    public void PlayEffect()
    {
        bloom.intensity.value = newBloomValue;
        remainingBloomTime = bloomDuration;
        beginRamp = true;
    }

    private void RampBloomDown()
    {
        if (remainingBloomTime > 0 && bloom.intensity.value > 1f)
        {
            remainingBloomTime -= Time.deltaTime;
            float bloomReduction = bloom.intensity.value * (Time.deltaTime / remainingBloomTime);
            bloom.intensity.value = ((remainingBloomTime / bloomDuration) > 0f) ? bloom.intensity.value - bloomReduction : 1f;
        }
        else
        {
            beginRamp = false;
        }
    }
}
