using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private LoginPlayerController controller;

    private void Awake()
    {
        controller = GetComponent<LoginPlayerController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        string playername = playernameInputField.text;
        string password = passwordInputField.text;

        controller.Send(playername, password, OnResult);
    }

    private void OnResult(string result)
    {
        if (result.StartsWith("{"))
        {
            LoginResultData loginResult = JsonUtility.FromJson<LoginResultData>(result);

            if (loginResult != null && loginResult.data != null)
            {
                PlayerSessionManager.Instance.SetLoggedInPlayer(loginResult.data.player_id, loginResult.data.player_name, loginResult.data.player_highscore);
                resultText.text = $"Sesión iniciada: {loginResult.data.player_name}! Highscore: {loginResult.data.player_highscore}";
            }
            else
            {
                resultText.text = "Error al iniciar sesión.";
            }
        }
        else
        {
            resultText.text = result;
        }
    }

}