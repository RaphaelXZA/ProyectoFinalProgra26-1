using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetItemsUI : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private Button button;
    private GetItemsController controller;

    private void Awake()
    {
        controller = GetComponent<GetItemsController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        controller.Send(OnResult);
    }

    private void OnResult(ItemResultData result)
    {
        if (result != null && result.data != null && result.data.Length > 0)
        {
            foreach (ItemData item in result.data)
            {
                GameObject row = Instantiate(prefab, container);
                row.GetComponent<TextMeshProUGUI>().text = $"{item.item_id} - {item.item_name}: {item.item_description}";
            }
        }
    }

}
