using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMover : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SongData _songData;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] Transform _notesParent;
    [SerializeField] FloatVariable _currentNoteSpeed;
    // Start is called before the first frame update
    public void OnGameRunningEntered()
    {
        StartCoroutine(nameof(MoveSong));
    }

    public void OnGameRunningExited()
    {
        StopCoroutine(nameof(MoveSong));
    }

    private IEnumerator MoveSong()
    {
        float bpm = _songData.bpm;
        float timeBetweenNotes = (1 / (bpm / 60));
        int notes = (int)((_songData.audioClip.length / 60) * bpm) - 1;
        float distanceToTravel = _currentNoteSpeed.value * timeBetweenNotes * notes;
        while (true)
        {
            float yPosition = Mathf.Lerp(0, distanceToTravel, _soundManager.bgmProgress);
            _notesParent.transform.localPosition = new Vector3 (0f, -yPosition, 0f);
            yield return null;
        }
    }
}
