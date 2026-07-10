using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchPlayersUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playernameInputField;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private Button button;
    private SearchPlayersController controller;

    private void Awake()
    {
        controller = GetComponent<SearchPlayersController>();
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
            foreach (PlayerData player in result.data)
            {
                GameObject row = Instantiate(prefab, container);
                row.GetComponent<TextMeshProUGUI>().text = $"{player.player_name} - {player.player_highscore}";
            }
        }
    }

}
