using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteItemUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField itemIdInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private DeleteItemController controller;

    private void Awake()
    {
        controller = GetComponent<DeleteItemController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        int itemId = int.Parse(itemIdInputField.text);

        controller.Send(itemId, OnResult);
    }

    private void OnResult(string result)
    {
        resultText.text = result;
    }

}
