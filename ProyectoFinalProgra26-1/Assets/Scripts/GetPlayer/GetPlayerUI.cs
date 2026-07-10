using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playernameInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private GetPlayerController controller;

    private void Awake()
    {
        controller = GetComponent<GetPlayerController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        string playername = playernameInputField.text;

        controller.Send(playername, OnResult);
    }

    private void OnResult(PlayerResultData result)
    {
        if (result != null && result.data != null && result.data.Length > 0)
        {
            PlayerData player = result.data[0];
            resultText.text = $"ID: {player.player_id} | Nombre: {player.player_name} | Highscore: {player.player_highscore}";
        }
        else
        {
            resultText.text = "Jugador no encontrado.";
        }
    }

}
