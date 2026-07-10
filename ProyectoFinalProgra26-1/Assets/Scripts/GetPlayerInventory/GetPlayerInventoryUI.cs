using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerIdInputField;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private Button button;
    private GetPlayerInventoryController controller;

    private void Awake()
    {
        controller = GetComponent<GetPlayerInventoryController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        int playerId = int.Parse(playerIdInputField.text);

        controller.Send(playerId, OnResult);
    }

    private void OnResult(PlayerInventoryResultData result)
    {
        if (result != null && result.data != null && result.data.Length > 0)
        {
            foreach (PlayerInventoryData item in result.data)
            {
                GameObject row = Instantiate(prefab, container);
                row.GetComponent<TextMeshProUGUI>().text = $"{item.item_name} - {item.item_description}";
            }
        }
    }

}
