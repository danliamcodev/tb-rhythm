using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hit Note Matrix", menuName = "Game Settings/Scoring/Hit Note Matrix")]
public class HitNoteMatrix : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] List<HitNoteTier> _hitNoteTiers;

    public List<HitNoteTier> hitNoteTiers => _hitNoteTiers;
}