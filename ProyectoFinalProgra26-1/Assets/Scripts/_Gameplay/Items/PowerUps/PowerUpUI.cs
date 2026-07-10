using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private Button portalButton;
    [SerializeField] private Button shieldButton;
    [SerializeField] private Button reducerButton;

    [SerializeField] private TextMeshProUGUI portalUsesText;
    [SerializeField] private TextMeshProUGUI shieldUsesText;
    [SerializeField] private TextMeshProUGUI reducerUsesText;

    private PowerUpInventory inventory;

    private void Awake()
    {
        inventory = FindFirstObjectByType<PowerUpInventory>();

        portalButton.onClick.AddListener(inventory.UsePortal);
        shieldButton.onClick.AddListener(inventory.UseShield);
        reducerButton.onClick.AddListener(inventory.UseReducer);
    }

    private void Update()
    {
        portalUsesText.text = $"x{inventory.portalUses}";
        shieldUsesText.text = $"x{inventory.shieldUses}";
        reducerUsesText.text = $"x{inventory.reducerUses}";
    }

}
