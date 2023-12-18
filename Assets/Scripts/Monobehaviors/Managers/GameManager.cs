using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] StateMachine _gameStateMachine;
    [SerializeField] LevelManager _levelManager;
    [Header("States")]
    [SerializeField] State _gameInitializing;
    [SerializeField] State _songLoading;
    [SerializeField] State _gameRunning;
    [SerializeField] State _wrappingUpSong;
    [SerializeField] State _postGame;

    private void Start()
    {
        StartCoroutine(nameof(StartGameLoop));
    }

    private IEnumerator StartGameLoop()
    {
        _gameStateMachine.ClearState();
        _gameStateMachine.SetState(_gameInitializing);

        yield return new WaitForSeconds(1f);

        _gameStateMachine.SetState(_songLoading);
    }

    public void OnSongLoaded()
    {
        _gameStateMachine.SetState(_gameRunning);
    }

    public void OnSongWrappedUp()
    {
        _gameStateMachine.SetState(_postGame);
    }

    public void OnNotesFinished()
    {
        _gameStateMachine.SetState(_wrappingUpSong);
    }

    public void OnPostGameEntered()
    {
        StartCoroutine(nameof(LoadNextLevel));
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1f);

        _levelManager.LoadLevel(3);
    }
}
