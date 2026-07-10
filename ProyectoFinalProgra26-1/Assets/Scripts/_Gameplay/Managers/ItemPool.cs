using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    public static ItemPool Instance { get; private set; }

    public List<int> AvailableItemIds { get; private set; } = new List<int>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetAvailableItems(ItemResultData result)
    {
        AvailableItemIds.Clear();

        if (result != null && result.data != null)
        {
            foreach (ItemData item in result.data)
            {
                AvailableItemIds.Add(item.item_id);
            }
        }
    }

}