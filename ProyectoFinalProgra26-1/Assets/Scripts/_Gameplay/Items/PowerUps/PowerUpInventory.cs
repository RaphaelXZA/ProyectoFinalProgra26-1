using UnityEngine;

public class PowerUpInventory : MonoBehaviour
{
    [Header("Uses")]
    public int portalUses = 0;
    public int shieldUses = 0;
    public int reducerUses = 0;

    [Header("Reducer settings")]
    [SerializeField] private float reducerDuration = 5f;
    [SerializeField] private float scaleReduction = 0.2f;

    [Header("Shield materials")]
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material shieldMaterial;

    private PlayerHealth playerHealth;
    private PlayerController playerController;
    private Renderer playerRenderer;

    private bool reducerActive = false;
    private float reducerTimer = 0f;
    private Vector3 originalScale;
    private float originalAcceleration;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerController = GetComponent<PlayerController>();
        playerRenderer = GetComponent<Renderer>();

        portalUses = GameManager.Instance.SavedPortalUses;
        shieldUses = GameManager.Instance.SavedShieldUses;
        reducerUses = GameManager.Instance.SavedReducerUses;
    }

    private void Update()
    {
        if (reducerActive)
        {
            reducerTimer += Time.deltaTime;
            if (reducerTimer >= reducerDuration)
            {
                DeactivateReducer();
            }
        }
    }

    public void AddPowerUp(int id)
    {
        switch (id)
        {
            case 1:
                portalUses++;
                break;
            case 2:
                shieldUses++;
                break;
            case 3:
                reducerUses++;
                break;
            default:
                break;
        }
    }

    
    public void UsePortal() //ID 1
    {
        if (portalUses <= 0) return;

        portalUses--;
        SaveAndExtract();
    }

    
    public void UseShield() //ID 2
    {
        if (shieldUses <= 0) return;
        if (playerHealth.GetHealth() > 1) return;

        shieldUses--;
        playerHealth.ChangeHealth(1);
        playerRenderer.material = shieldMaterial;
    }

    public void OnShieldLost()
    {
        playerRenderer.material = normalMaterial;
    }

    
    public void UseReducer() //ID 3
    {
        if (reducerUses <= 0) return;
        if (reducerActive) return;

        reducerUses--;
        reducerActive = true;
        reducerTimer = 0f;

        originalScale = transform.localScale;
        originalAcceleration = playerController.accelerationForce;

        transform.localScale -= Vector3.one * scaleReduction;
        playerController.accelerationForce *= 2f;
    }

    private void DeactivateReducer()
    {
        reducerActive = false;
        transform.localScale = originalScale;
        playerController.accelerationForce = originalAcceleration;
    }

    public void SaveAndExtract()
    {
        GameManager.Instance.SavePowerUpUses(portalUses, shieldUses, reducerUses);
        FindFirstObjectByType<ScoreCounter>().SaveScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameExtracted");
    }

}