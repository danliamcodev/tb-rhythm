using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Song Data", menuName = "Songs/Song Data")]
public class SongData : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] AudioClip _audioClip;
    [SerializeField] float _delayBeats;
    [SerializeField] float _bpm;
    [SerializeField] GameObject _noteComposition;

    public AudioClip audioClip => _audioClip;
    public float delayBeats => _delayBeats;
    public float bpm => _bpm;
    public GameObject noteComposition => _noteComposition;
}



