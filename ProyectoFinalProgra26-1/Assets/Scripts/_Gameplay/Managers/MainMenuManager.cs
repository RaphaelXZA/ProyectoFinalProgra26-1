using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelsPanel;

    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private GameObject deletePlayerPanel;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private Transform inventoryContainer;

    private GetPlayerInventoryController inventoryController;

    private void Awake()
    {
        inventoryController = GetComponent<GetPlayerInventoryController>();
    }

    public void ToggleLevelsPanel()
    {
        levelsPanel.SetActive(!levelsPanel.activeSelf);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void ToggleCreditsPanel()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }

    public void ToggleDeletePlayerPanel()
    {
        deletePlayerPanel.SetActive(!deletePlayerPanel.activeSelf);
    }

    public void GoToDeletePlayer()
    {
        SceneManager.LoadScene("DeletePlayer");
    }

    public void ToggleInventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void LoadInventory()
    {
        foreach (Transform child in inventoryContainer)
        {
            Destroy(child.gameObject);
        }

        inventoryController.Send(PlayerSessionManager.Instance.PlayerId, OnInventoryResult);
    }

    private void OnInventoryResult(PlayerInventoryResultData result)
    {
        if (result != null && result.data != null && result.data.Length > 0)
        {
            foreach (PlayerInventoryData item in result.data)
            {
                GameObject row = Instantiate(inventoryItemPrefab, inventoryContainer);
                row.GetComponent<TextMeshProUGUI>().text = $"{item.item_name} - {item.item_description}";
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
