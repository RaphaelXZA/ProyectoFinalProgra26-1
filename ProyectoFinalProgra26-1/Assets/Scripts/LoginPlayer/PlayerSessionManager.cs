using UnityEngine;

public class PlayerSessionManager : MonoBehaviour
{
    public static PlayerSessionManager Instance { get; private set; }

    public int PlayerId { get; private set; }
    public string PlayerName { get; private set; }
    public int PlayerHighscore { get; private set; }
    public bool IsLoggedIn { get; private set; }

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

    public void SetLoggedInPlayer(int playerId, string playerName, int playerHighscore)
    {
        PlayerId = playerId;
        PlayerName = playerName;
        PlayerHighscore = playerHighscore;
        IsLoggedIn = true;
    }

    public void Logout()
    {
        PlayerId = 0;
        PlayerName = null;
        PlayerHighscore = 0;
        IsLoggedIn = false;
    }

}