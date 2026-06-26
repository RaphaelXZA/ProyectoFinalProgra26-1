using TMPro;
using UnityEngine;

public class GetItemsPerPlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    private GetItemsPerPlayerController controller;

    private void Awake()
    {
        controller = GetComponent<GetItemsPerPlayerController>();
    }

    public void Send()
    {
        controller.Send(OnResult);
    }

    private void OnResult(ItemsPerPlayerResultData result)
    {
        if (result != null && result.data != null && result.data.Length > 0)
        {
            foreach (ItemsPerPlayerData row in result.data)
            {
                GameObject item = Instantiate(prefab, container);
                item.GetComponent<TextMeshProUGUI>().text = $"Player ID {row.player_id} - {row.total_items} items";
            }
        }
    }

}
