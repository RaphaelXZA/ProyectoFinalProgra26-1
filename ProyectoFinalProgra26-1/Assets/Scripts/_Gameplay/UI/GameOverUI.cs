using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private void Start()
    {
        scoreText.text = $"Score: {GameManager.Instance.CurrentScore}";
        highscoreText.text = $"Highscore: {GameManager.Instance.Highscore}";
    }

}