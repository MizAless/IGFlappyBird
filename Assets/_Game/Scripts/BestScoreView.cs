using TMPro;
using UnityEngine;

public class BestScoreView : MonoBehaviour
{
    private const string BestScoreText = "Best score:";

    [SerializeField] private TextMeshProUGUI _bestScoreText;

    [SerializeField] private BestScore _bestScore;

    private void OnEnable()
    {
        _bestScore.Changed += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        _bestScore.Changed -= UpdateText;
    }

    private void UpdateText(int newValue)
    {
        _bestScoreText.text = BestScoreText + " " + newValue.ToString();
    }

    private void UpdateText()
    {
        UpdateText(_bestScore.Value);
    }
}
