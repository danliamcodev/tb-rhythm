using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongDiagnostics : MonoBehaviour
{
    [Header("States")]
    [SerializeField] State _gamePaused;
    [Header("References")]
    //[SerializeField] PlayerInputReference _playerInputReference;
    [SerializeField] StateMachine _gameStateMachine;

    [Header("Parameters")]
    [SerializeField] bool _pauseOnFirstNote = false;
    [SerializeField] float _timeBeforeFirstNote;

    private PlayerControls _playerControls;
    private bool _testActivated = false;
    private int _testBeats = 0;
    private float _time;

    private bool _firstNoteTimerActive = false;
    private bool _firstNotePerformed = false;
    private float _firstNoteTimer = 0;

    /*
    private void Awake()
    {
        _playerControls = _playerInputReference.playerControls;
    }

    private void OnEnable()
    {

        _playerControls.Gameplay.Note1.performed += context => PerformNote(0);
        _playerControls.Gameplay.Note2.performed += context => PerformNote(1);
        _playerControls.Gameplay.Note3.performed += context => PerformNote(2);
        _playerControls.Gameplay.Note4.performed += context => PerformNote(3);
        _playerControls.Gameplay.Note5.performed += context => PerformNote(4);
    }

    private void OnDisable()
    {
        _playerControls.Gameplay.Note1.performed -= context => PerformNote(0);
        _playerControls.Gameplay.Note2.performed -= context => PerformNote(1);
        _playerControls.Gameplay.Note3.performed -= context => PerformNote(2);
        _playerControls.Gameplay.Note4.performed -= context => PerformNote(3);
        _playerControls.Gameplay.Note5.performed -= context => PerformNote(4);
    }
    */

    private void Start()
    {
        StartCoroutine(nameof(GetBPMTask));
    }

    private void Update()
    {
        if (_firstNoteTimerActive)
        {
            _firstNoteTimer += Time.deltaTime;
        }
    }

    private void PerformNote(int p_index)
    {
        _testBeats++;

        if (!_firstNotePerformed)
        {
            _firstNotePerformed = true;
        }
    }

    public void OnGameRunningEnter()
    {
        _firstNoteTimerActive = true;

        if (_pauseOnFirstNote)
        {
            StartCoroutine(nameof(PauseOnFirstNote));
        }
    }

    private IEnumerator GetBPMTask()
    {
        while(_testBeats < 30)
        {
            while (_testBeats > 0)
            {
                _time += Time.deltaTime;
                if (_testBeats >= 30)
                {
                    print(string.Format("Beats: {0} Time: {1}", _testBeats - 1, _time));
                    print(string.Format("BPM: {0}", (60f / _time) * (_testBeats - 1)));
                    StopCoroutine(nameof(GetBPMTask));
                }
                yield return null;
            }
            yield return null;
        }
    }

    private IEnumerator PauseOnFirstNote()
    {
        yield return new WaitForSeconds(_timeBeforeFirstNote);

        _gameStateMachine.SetState(_gamePaused);
        Time.timeScale = 0;
    }
}
