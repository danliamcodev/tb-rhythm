using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtNoteChecker : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] CaughtNoteCheckResultEvent _caughtNoteChecked;
    [Header("References")]
    [SerializeField] HitNoteMatrix _hitNoteMatrix;
    public void OnNoteCaught(CaughtNote p_caughtNote)
    {
        CheckCaughtNote(p_caughtNote);
    }

    private void CheckCaughtNote(CaughtNote p_caughtNote)
    {
        HitNoteTier caughtNoteTier = _hitNoteMatrix.hitNoteTiers[0];
        foreach (HitNoteTier hitNoteTier in _hitNoteMatrix.hitNoteTiers)
        {
            if (p_caughtNote.distanceFromCatcher <= hitNoteTier.distanceThreshold)
            {
                caughtNoteTier = hitNoteTier;
                break;
            }
        }
        _caughtNoteChecked.Raise(new CaughtNoteCheckResult(p_caughtNote.note, caughtNoteTier));
    }
}

public class CaughtNoteCheckResult
{
    Note _note;
    HitNoteTier _hitNoteTier;

    public Note note => _note;
    public HitNoteTier hitNoteTier => _hitNoteTier;

    public CaughtNoteCheckResult(Note p_note, HitNoteTier p_hitNoteTier)
    {
        _note = p_note;
        _hitNoteTier = p_hitNoteTier;
    }
}
