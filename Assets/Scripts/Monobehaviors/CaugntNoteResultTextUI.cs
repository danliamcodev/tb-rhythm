using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CaugntNoteResultTextUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI _caughtNoteResultText;
    [Header("Parameters")]
    [SerializeField] float _firstFloatDistance;
    [SerializeField] float _firstFloatTime;
    [SerializeField] float _secondFloatDistance;
    [SerializeField] float _secondFloatTime;

    RectTransform _rectTransform;

    Vector2 _originalPosition;
    private void Awake()
    {
        _caughtNoteResultText = GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
        _caughtNoteResultText.text = "";
        _originalPosition = transform.position;
    }

    public void OnCaughtNoteChecked(CaughtNoteCheckResult p_result)
    {
        _caughtNoteResultText.text = string.Format("{0}!", p_result.hitNoteTier.tierName);
        StopAllCoroutines();
        StartCoroutine(nameof(DisplayNoteResultTask));
    }

    private IEnumerator DisplayNoteResultTask()
    {
        Color color = _caughtNoteResultText.color;
        color.a = 1;
        transform.position = _originalPosition;
        _caughtNoteResultText.color = color;
        // First Movement
        float firstFloatTimer = 0;
        while (firstFloatTimer < _firstFloatTime)
        {
            float t = firstFloatTimer / _firstFloatTime;
            float yPosition = Mathf.SmoothStep(_originalPosition.y, _originalPosition.y + (_rectTransform.rect.height * _firstFloatDistance), t);
            transform.position = new Vector2(transform.position.x, yPosition);
            firstFloatTimer += Time.deltaTime;
            yield return null;
        }

        // Second Movement
        float secondFloatTimer = 0;

        while (secondFloatTimer < _secondFloatTime)
        {
            float t = secondFloatTimer / _secondFloatTime;
            float yPosition = Mathf.SmoothStep(_originalPosition.y + (_rectTransform.rect.height * _firstFloatDistance), _originalPosition.y + (_rectTransform.rect.height * (_firstFloatDistance + _secondFloatDistance)), t);
            float alpha = Mathf.SmoothStep(1, 0, t);
            color.a = alpha;
            _caughtNoteResultText.color = color;
            transform.position = new Vector2(transform.position.x, yPosition);
            secondFloatTimer += Time.deltaTime;
            yield return null;
        }
    }
}
