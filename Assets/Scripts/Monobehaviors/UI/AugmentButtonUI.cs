using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AugmentButtonUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI _buttonText;

    public delegate void AugmentButtonEvent(Augment p_augment);
    public AugmentButtonEvent buttonPressed;
    Augment _assignedAugment;

    public Augment assignedAugment => _assignedAugment;
    public void ConfigureAugmentButton(Augment p_augmentToAssign)
    {
        print(p_augmentToAssign);
        _assignedAugment = p_augmentToAssign;
        _buttonText.text = p_augmentToAssign.description;
    }

    public void OnAugmentButtonPressed()
    {
        buttonPressed.Invoke(_assignedAugment);
    }
}
