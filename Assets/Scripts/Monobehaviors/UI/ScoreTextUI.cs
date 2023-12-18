using UnityEngine;
using TMPro;

public class ScoreTextUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] FloatVariable _score;
    [SerializeField] TextMeshProUGUI _scoreText;

    public void OnScoreUpdated()
    {
        SetScoreText();
    }

    public void SetScoreText()
    {
        _scoreText.text = _score.value.ToString();
    }

    private void OnEnable()
    {
        _scoreText.text = _score.value.ToString();
    }
}
