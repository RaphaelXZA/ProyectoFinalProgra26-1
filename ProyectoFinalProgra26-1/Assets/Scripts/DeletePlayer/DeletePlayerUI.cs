using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeletePlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerIdInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private DeletePlayerController controller;

    private void Awake()
    {
        controller = GetComponent<DeletePlayerController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        int playerId = int.Parse(playerIdInputField.text);

        controller.Send(playerId, OnResult);
    }

    private void OnResult(string result)
    {
        resultText.text = result;
    }

}
