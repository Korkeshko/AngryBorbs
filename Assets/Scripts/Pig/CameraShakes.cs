using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraShakes : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    private float duration = 0.5f;
    [SerializeField]
    private AnimationCurve amplitude;
    [SerializeField]
    private AnimationCurve frequency;
    private CinemachineBasicMultiChannelPerlin component;

    private void Awake()
    {
        component = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake()
    {
        float time = 0;
        DOTween.To(
            () => time,
            value =>
            {
                time = value;
                component.m_AmplitudeGain = amplitude.Evaluate(time);
                component.m_FrequencyGain = frequency.Evaluate(time);
            },
            1,
            duration   
        ).OnComplete(() =>
        {
            component.m_AmplitudeGain = 0;
            component.m_FrequencyGain = 0;
        });
    }
    // private void FinishShake()
    // {
    //     component.m_AmplitudeGain = 0;
    //     component.m_FrequencyGain = 0;
    // }
}
