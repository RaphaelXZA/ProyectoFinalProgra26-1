using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginPlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button button;
    [SerializeField] private GameObject registerPanel;
    private LoginPlayerController loginController;
    private GetItemsController itemsController;
    private GetPlayerInventoryController inventoryController;

    private void Awake()
    {
        loginController = GetComponent<LoginPlayerController>();
        itemsController = GetComponent<GetItemsController>();
        inventoryController = GetComponent<GetPlayerInventoryController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        string playername = playernameInputField.text;
        string password = passwordInputField.text;

        loginController.Send(playername, password, OnLoginResult);
    }

    private void OnLoginResult(string result)
    {
        if (result.StartsWith("{"))
        {
            LoginResultData loginResult = JsonUtility.FromJson<LoginResultData>(result);

            if (loginResult != null && loginResult.data != null)
            {
                PlayerSessionManager.Instance.SetLoggedInPlayer(
                    loginResult.data.player_id,
                    loginResult.data.player_name,
                    loginResult.data.player_highscore
                );

                resultText.text = "Cargando datos...";
                itemsController.Send(OnItemsResult);
            }
            else
            {
                resultText.text = "Error al iniciar sesión.";
            }
        }
        else
        {
            resultText.text = result;
        }
    }

    private void OnItemsResult(ItemResultData result)
    {
        ItemPool.Instance.SetAvailableItems(result);
        inventoryController.Send(PlayerSessionManager.Instance.PlayerId, OnInventoryResult);
    }

    private void OnInventoryResult(PlayerInventoryResultData result)
    {
        int portalUses = 0;
        int shieldUses = 0;
        int reducerUses = 0;

        if (result != null && result.data != null)
        {
            foreach (PlayerInventoryData item in result.data)
            {
                if (item.item_id == 1) portalUses++;
                else if (item.item_id == 2) shieldUses++;
                else if (item.item_id == 3) reducerUses++;
            }
        }

        GameManager.Instance.SavePowerUpUses(portalUses, shieldUses, reducerUses);
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleRegisterPanel()
    {
        registerPanel.SetActive(!registerPanel.activeSelf);
    }

}