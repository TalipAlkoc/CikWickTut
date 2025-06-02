using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }


    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

    private float _shakeTimer;
    private float _shakeTimerTotal;

    private float _startingIntensity;

    private void Awake()
    {
        Instance = this;
        _cinemachineBasicMultiChannelPerlin = GetComponent<CinemachineBasicMultiChannelPerlin>();
    }


    private IEnumerator CamerShakeCorotine(float intensity,float time,float deley)
    {
        yield return new WaitForSeconds(deley);
        _cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;
        _shakeTimer = time;
        _shakeTimerTotal = time;
        _startingIntensity = intensity;
    }

    public void ShakeCamera(float intensity,float time, float deley =0f)
    {
        StartCoroutine(CamerShakeCorotine(intensity, time, deley));
    }


    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;

            if (_shakeTimer <= 0)
            {
                _cinemachineBasicMultiChannelPerlin.AmplitudeGain
                    = Mathf.Lerp(_startingIntensity, 0f, 1 - (_shakeTimer / _shakeTimerTotal));
            }
        }
    }



}
 