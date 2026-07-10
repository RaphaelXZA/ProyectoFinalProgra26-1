using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 3f;
    [SerializeField] public int powerUpId;

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PowerUpInventory>().AddPowerUp(powerUpId);
            Destroy(gameObject);
        }
    }

}
