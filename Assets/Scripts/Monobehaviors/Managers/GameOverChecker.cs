using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    [Header("Evenets")]
    [SerializeField] VoidEvent _notesFinished;
    [Header("References")]
    [SerializeField] SongData _songData;
    [Header("Parameters")]
    [SerializeField] int _lazyMaxNotes;

    int _caughtNotes = 0;

    public void OnNoteCaught()
    {
        _caughtNotes++;
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if (_caughtNotes >= _lazyMaxNotes)
        {
            _notesFinished.Raise();
        }
    }
}
