using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExtractedUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private UpdateScoreController updateScoreController;
    private RemoveItemFromPlayerController removeItemController;
    private AddItemToPlayerController addItemController;

    private void Awake()
    {
        updateScoreController = GetComponent<UpdateScoreController>();
        removeItemController = GetComponent<RemoveItemFromPlayerController>();
        addItemController = GetComponent<AddItemToPlayerController>();
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

        SaveInventoryToDB();
    }

    private void SaveInventoryToDB()
    {
        int playerId = PlayerSessionManager.Instance.PlayerId;

        foreach (int itemId in ItemPool.Instance.AvailableItemIds)
        {
            removeItemController.Send(playerId, itemId, null);
        }

        for (int i = 0; i < GameManager.Instance.SavedPortalUses; i++)
            addItemController.Send(playerId, 1, null);

        for (int i = 0; i < GameManager.Instance.SavedShieldUses; i++)
            addItemController.Send(playerId, 2, null);

        for (int i = 0; i < GameManager.Instance.SavedReducerUses; i++)
            addItemController.Send(playerId, 3, null);
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(GameManager.Instance.LastLevel);
    }

    private void OnScoreUpdated(string result)
    {
        Debug.Log("Score updated: " + result);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}