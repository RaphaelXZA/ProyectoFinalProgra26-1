using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RemoveItemFromPlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerIdInputField;
    [SerializeField] private TMP_InputField itemIdInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private RemoveItemFromPlayerController controller;

    private void Awake()
    {
        controller = GetComponent<RemoveItemFromPlayerController>();
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
