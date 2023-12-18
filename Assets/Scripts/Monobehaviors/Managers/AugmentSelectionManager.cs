using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentSelectionManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] AugmentsSet _allAugments;
    [SerializeField] AugmentsSet _activeAugments;
    [SerializeField] List<AugmentButtonUI> _augmentButtons;

    private void Awake()
    {
        List<Augment> augmentPool = new List<Augment>(_allAugments.items);
        foreach (Augment augment in _activeAugments.items)
        {

            augmentPool.Remove(augment);
        }

        foreach(AugmentButtonUI augmentButton in _augmentButtons)
        {
            int randomAugmentIndex = Random.Range(0, augmentPool.Count);
            Augment randomAugment = augmentPool[randomAugmentIndex];
            augmentButton.ConfigureAugmentButton(randomAugment);
            augmentPool.Remove(randomAugment);
        }
    }

    private void OnEnable()
    {
        foreach (AugmentButtonUI augmentButton in _augmentButtons)
        {
            augmentButton.buttonPressed += AddAugmentToActiveAugments;
        }
    }

    private void OnDisable()
    {
        foreach (AugmentButtonUI augmentButton in _augmentButtons)
        {
            augmentButton.buttonPressed -= AddAugmentToActiveAugments;
        }
    }
    public void AddAugmentToActiveAugments (Augment p_augment)
    {
        _activeAugments.Add(p_augment);
    }
}
