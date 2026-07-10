using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CurrentScore { get; private set; }
    public int Highscore { get; private set; }

    public int SavedPortalUses { get; private set; }
    public int SavedShieldUses { get; private set; }
    public int SavedReducerUses { get; private set; }

    public string LastLevel;

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

    public void SavePowerUpUses(int portal, int shield, int reducer)
    {
        SavedPortalUses = portal;
        SavedShieldUses = shield;
        SavedReducerUses = reducer;
    }

    public void ClearPowerUpUses()
    {
        SavedPortalUses = 0;
        SavedShieldUses = 0;
        SavedReducerUses = 0;
    }

}