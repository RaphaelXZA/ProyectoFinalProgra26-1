using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddItemToPlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerIdInputField;
    [SerializeField] private TMP_InputField itemIdInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private AddItemToPlayerController controller;

    private void Awake()
    {
        controller = GetComponent<AddItemToPlayerController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        int playerId = int.Parse(playerIdInputField.text);
        int itemId = int.Parse(itemIdInputField.text);

        controller.Send(playerId, itemId, OnResult);
    }

    private void OnResult(string result)
    {
        resultText.text = result;
    }

}
