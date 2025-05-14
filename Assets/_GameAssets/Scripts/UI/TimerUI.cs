using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private RectTransform _timerRotatableTransform;
    [SerializeField] private TMP_Text _timerText;

    [Header("Settings")]
    [SerializeField] private float _rotationDuration;
    [SerializeField] private Ease _rotationEase;

    private float _elapsedTime;//geçen süre

    private bool _isTimeRunning;
    private Tween _rotationTween;


    private void Start()
    {
        PlayRotationAnimation();
        StartTimer();

        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Pause:
                //PAUSE TIMER
                PauseTımer();
                break;
            case GameState.Resume:
                ResumeTımer();
                //RESUME TIMER
                break;
               
        }
    }

    private void PlayRotationAnimation()
    {
       _rotationTween = _timerRotatableTransform.DORotate(new Vector3(0f, 0f, -360f), _rotationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(_rotationEase);
    }

    private void StartTimer()
    {
        _isTimeRunning = true;
        _elapsedTime = 0f;
        InvokeRepeating(nameof(UpadateTimerUI), 0f, 1f);
    }

    private void PauseTımer()
    {
        _isTimeRunning = false;
        CancelInvoke(nameof(UpadateTimerUI));
        _rotationTween.Pause();
    }

    private void ResumeTımer()
    {
        if (!_isTimeRunning)
        {
            _isTimeRunning = true;
            InvokeRepeating(nameof(UpadateTimerUI), 0f, 1f);
            _rotationTween.Play();
        }
    }


    private void UpadateTimerUI()
    {
        if (!_isTimeRunning)
        {
            return;
        }
        _elapsedTime += 1f;

        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
