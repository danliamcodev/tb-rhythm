using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCatcherActivator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _noteCatcherParent;

    PlayerInputHandler _playerInputHandler;

    List<NoteCatcher> _noteCatchers = new List<NoteCatcher>();

    private void Awake()
    {
        _playerInputHandler = GetComponent<PlayerInputHandler>();

        for (int i = 0; i < _noteCatcherParent.childCount; i++)
        {
            _noteCatchers.Add(_noteCatcherParent.GetChild(i).GetComponent<NoteCatcher>());
        }
    }

    private void OnEnable()
    {
        _playerInputHandler.notePerformed += OnNoteInputPerformed;
    }

    private void OnDisable()
    {
        _playerInputHandler.notePerformed -= OnNoteInputPerformed;
    }

    public void OnNoteInputPerformed(int p_noteIndex)
    {
        _noteCatchers[p_noteIndex].CatchNote();
    }
}
