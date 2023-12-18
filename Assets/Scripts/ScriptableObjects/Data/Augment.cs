using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Augment", menuName = "Augments/Augment")]
public class Augment : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] string _description;
    [SerializeField] List<FloatAugmentModifier> _floatAugmentModifiers;

    public string description => _description;
    public List<FloatAugmentModifier> floatAugmentModifiers => _floatAugmentModifiers;
}

[System.Serializable]
public class FloatAugmentModifier
{
    [SerializeField] FloatVariable _propertyToModify;
    [SerializeField] float _valueToAdd = 0;
    [SerializeField] float _valueToMultiply = 1;

    public FloatVariable propertyToModify => _propertyToModify;
    public float valueToAdd => _valueToAdd;
    public float valueToMultiply => _valueToMultiply;
}
