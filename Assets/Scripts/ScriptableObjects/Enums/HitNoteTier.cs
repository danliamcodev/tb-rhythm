using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Hit Note Tier", menuName = "Enums/Hit Note Tier")]
public class HitNoteTier : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] string _tierName;
    [SerializeField] float _distanceThreshold;
    [SerializeField] float _score;

    public string tierName => _tierName;
    public float distanceThreshold => _distanceThreshold;
    public float score => _score;
}
