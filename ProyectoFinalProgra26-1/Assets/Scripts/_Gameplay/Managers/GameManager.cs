using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CurrentScore { get; private set; }
    public int Highscore { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetScore(int score)
    {
        CurrentScore = score;

        if (CurrentScore > Highscore)
        {
            Highscore = CurrentScore;
        }
    }

}
