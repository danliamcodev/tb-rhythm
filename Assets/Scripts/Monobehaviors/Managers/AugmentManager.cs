using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] AugmentsSet _activeAugments;
    [SerializeField] FloatVariable _defaultNoteSpeed;
    [SerializeField] FloatVariable _noteSpeedMultiplier;
    [SerializeField] FloatVariable _currentNoteSpeed;

    Dictionary<FloatVariable, float> _defaultFloatValues = new Dictionary<FloatVariable, float>();

    public void OnGameInitializeEntered()
    {
        ApplyAugments();
    }

    private void ApplyAugments()
    {
        foreach (Augment augment in _activeAugments.items)
        {
            foreach (FloatAugmentModifier floatAugmentModifier in augment.floatAugmentModifiers)
            {
                SaveDefaultFloatValue(floatAugmentModifier.propertyToModify);
                ApplyAdditiveAugmentChange(floatAugmentModifier);
            }

            foreach (FloatAugmentModifier floatAugmentModifier in augment.floatAugmentModifiers)
            {
                ApplyMultiplicativeAugmentChange(floatAugmentModifier);
            }
        }

        _currentNoteSpeed.SetValue(_defaultNoteSpeed.value * _noteSpeedMultiplier.value);
    }

    private void OnDisable()
    {
        RevertDefaultFloatValues();
    }

    private void ApplyAdditiveAugmentChange(FloatAugmentModifier p_floatAugmentModifier)
    {
        p_floatAugmentModifier.propertyToModify.ApplyChange(p_floatAugmentModifier.valueToAdd);
    }

    private void ApplyMultiplicativeAugmentChange(FloatAugmentModifier p_floatAugmentModifier)
    {
        p_floatAugmentModifier.propertyToModify.SetValue(p_floatAugmentModifier.propertyToModify.value * p_floatAugmentModifier.valueToMultiply);
    }

    private void SaveDefaultFloatValue(FloatVariable p_floatVariable)
    {
        if (_defaultFloatValues.ContainsKey(p_floatVariable)) return;
        _defaultFloatValues.Add(p_floatVariable, p_floatVariable.value);
    }

    private void RevertDefaultFloatValues()
    {
        foreach (Augment augment in _activeAugments.items)
        {
            foreach (FloatAugmentModifier floatAugmentModifier in augment.floatAugmentModifiers)
            {
                floatAugmentModifier.propertyToModify.SetValue(_defaultFloatValues[floatAugmentModifier.propertyToModify]);
            }
        }
    }
}
