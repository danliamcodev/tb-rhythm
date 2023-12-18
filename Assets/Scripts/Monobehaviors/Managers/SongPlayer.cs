using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _songWrappedUp;
    [Header("References")]
    [SerializeField] SoundManager _soundManager;
    [Header("Parameters")]
    [SerializeField] AudioClip _testSong;
    [SerializeField] float _wrapUpDuration = 3f;

    public void OnGameRunningEntered()
    {
        _soundManager.PlayBGM(_testSong, true);
    }

    public void OnGamePauseEntered()
    {
        _soundManager.PauseBGM();
    }

    public void OnWrappingUpSongEntered()
    {
        StartCoroutine(WrapUpSongTask(_wrapUpDuration));
    }

    private IEnumerator WrapUpSongTask(float p_duration)
    {
        _soundManager.FadeOutBGM(p_duration);

        yield return new WaitForSeconds(p_duration);

        _songWrappedUp.Raise();
    }
}
