using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _scoreUpdated;
    [Header("References")]
    [SerializeField] FloatVariable _playerScore;
    [SerializeField] FloatVariable _scoreMultiplier;
    public void OnCaughtNoteChecked(CaughtNoteCheckResult p_result) {
        AddScore(p_result.hitNoteTier.score * _scoreMultiplier.value);
    }

    private void AddScore(float p_score)
    {
        _playerScore.ApplyChange(p_score);
        _scoreUpdated.Raise();
    }
}
