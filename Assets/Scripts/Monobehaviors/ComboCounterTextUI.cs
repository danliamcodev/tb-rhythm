using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounterTextUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] IntVariable _comboCounter;
    TextMeshProUGUI _comboCounterText;
    private void Awake()
    {
        _comboCounterText = GetComponent<TextMeshProUGUI>();
        _comboCounterText.text = "";
    }

    public void OnComboLost()
    {
        _comboCounterText.text = "";
    }

    public void OnPlayerComboing()
    {
        _comboCounterText.text = _comboCounter.value.ToString();
    }
}
