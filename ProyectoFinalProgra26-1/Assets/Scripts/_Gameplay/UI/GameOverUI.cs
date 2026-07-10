using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private UpdateScoreController updateScoreController;
    private RemoveItemFromPlayerController removeItemController;

    private void Awake()
    {
        updateScoreController = GetComponent<UpdateScoreController>();
        removeItemController = GetComponent<RemoveItemFromPlayerController>();
    }

    private void Start()
    {
        scoreText.text = $"Score: {GameManager.Instance.CurrentScore}";
        highscoreText.text = $"Highscore: {GameManager.Instance.Highscore}";

        if (GameManager.Instance.CurrentScore > PlayerSessionManager.Instance.PlayerHighscore)
        {
            updateScoreController.Send(
                PlayerSessionManager.Instance.PlayerId,
                GameManager.Instance.CurrentScore,
                OnScoreUpdated
            );
        }

        int playerId = PlayerSessionManager.Instance.PlayerId;
        foreach (int itemId in ItemPool.Instance.AvailableItemIds)
        {
            removeItemController.Send(playerId, itemId, null);
        }
    }

    private void OnScoreUpdated(string result)
    {
        Debug.Log("Score updated: " + result);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(GameManager.Instance.LastLevel);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}