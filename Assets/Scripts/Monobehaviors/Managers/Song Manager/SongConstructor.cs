using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongConstructor : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _songLoaded;
    [Header("References")]
    [SerializeField] SongData _songData;
    [SerializeField] FloatVariable _currentNoteSpeed;
    [SerializeField] Transform _sampleNoteCatcher;
    [SerializeField] Transform _notesParent;
    [SerializeField] ObjectPoolController _noteObjectPoolController;

    private void Awake()
    {
        _noteObjectPoolController.AddObjectsToPool(_songData.noteComposition.transform.childCount);
    }

    public void OnSongLoadingEntered()
    {
        ConstructSong();
        _songLoaded.Raise();
    }


    private void ConstructSong()
    {
        float firstNoteTime = 2.58f;
        float bpm = _songData.bpm;
        float timeBetweenNotes = (1 / (bpm / 60));
        float distanceBetweenNotes = _currentNoteSpeed.value * timeBetweenNotes;
        float baseY = (firstNoteTime / timeBetweenNotes) * distanceBetweenNotes; 


        for (int i = 0; i < _songData.noteComposition.transform.childCount; i++)
        {
            GameObject note = _noteObjectPoolController.GetObject();
            note.transform.SetParent(_notesParent);
            note.transform.rotation = _sampleNoteCatcher.rotation;
            Vector3 localPosition = _songData.noteComposition.transform.GetChild(i).transform.position;
            localPosition.y = baseY + (localPosition.y * distanceBetweenNotes);
            note.transform.localPosition = localPosition;
            note.SetActive(true);
        }
    }
}
