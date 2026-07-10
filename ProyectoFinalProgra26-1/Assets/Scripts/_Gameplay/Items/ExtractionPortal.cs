using UnityEngine;

public class ExtractionPortal : ObstacleBase
{
    protected override void ExtraMovement() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PowerUpInventory>().SaveAndExtract();
        }
    }

}