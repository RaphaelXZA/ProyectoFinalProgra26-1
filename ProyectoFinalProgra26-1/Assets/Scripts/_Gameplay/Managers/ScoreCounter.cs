using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private float timer = 0f;
    private int score = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            score++;
            timer = 0f;
            scoreText.text = $"Score: {score}";
        }
    }

    public void SaveScore()
    {
        GameManager.Instance.SetScore(score);
    }

}
