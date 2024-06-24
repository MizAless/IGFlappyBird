using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private const string Score = "Score:";

    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _score.Changed += UpdateText;
    }

    private void OnDisable()
    {
        _score.Changed -= UpdateText;
    }

    private void UpdateText(int newValue)
    {
        _scoreText.text = Score + " " + newValue.ToString();
    }
}
