using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddItemUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField itemNameInputField;
    [SerializeField] private TMP_InputField itemDescriptionInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private AddItemController controller;

    private void Awake()
    {
        controller = GetComponent<AddItemController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        string itemName = itemNameInputField.text;
        string itemDescription = itemDescriptionInputField.text;

        controller.Send(itemName, itemDescription, OnResult);
    }

    private void OnResult(string result)
    {
        resultText.text = result;
    }

}