using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetItemOwnerCountUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField itemIdInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    private GetItemOwnerCountController controller;

    private void Awake()
    {
        controller = GetComponent<GetItemOwnerCountController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        int itemId = int.Parse(itemIdInputField.text);

        controller.Send(itemId, OnResult);
    }

    private void OnResult(ItemOwnerCountResultData result)
    {
        if (result != null)
        {
            resultText.text = $"Jugadores que poseen este objeto: {result.data}";
        }
        else
        {
            resultText.text = "No se encontro el objeto.";
        }
    }

}
