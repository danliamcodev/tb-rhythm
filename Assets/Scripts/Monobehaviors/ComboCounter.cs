using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _comboLost;
    [SerializeField] VoidEvent _playerComboing;
    [Header("References")]
    [SerializeField] HitNoteMatrix _hitNoteMatrix;
    [Header("Parameters")]
    [SerializeField] HitNoteTier _tierThreshold;
    [SerializeField] int _minComboCount = 3;
    [SerializeField] IntVariable _comboCount;

    private void Awake()
    {
        _comboCount.SetValue(0);
    }
    public void OnCaughtNoteChecked(CaughtNoteCheckResult p_result)
    {
        if (p_result.hitNoteTier.distanceThreshold <= _tierThreshold.distanceThreshold)
        {
            _comboCount.ApplyChange(1);
            if (_comboCount.value >= _minComboCount)
            {
                _playerComboing.Raise();
            }
        } else
        {
            if (_comboCount.value >= _minComboCount)
            {
                _comboLost.Raise();
            }
            _comboCount.SetValue(0);
   
        }
    }
}
