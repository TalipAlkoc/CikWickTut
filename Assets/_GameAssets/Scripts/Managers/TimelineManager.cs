using System;
using UnityEngine;
using UnityEngine.Playables;


public class TimelineManager : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;


    private PlayableDirector _playableDirector;
    private object imelineFinished;

    private void Awake()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        _playableDirector.Play();
        _playableDirector.stopped += OnTimelineFinished;
    }

    private void OnTimelineFinished(PlayableDirector obj)
    {
        _gameManager.ChangeGameState(GameState.Play);
    }
}
