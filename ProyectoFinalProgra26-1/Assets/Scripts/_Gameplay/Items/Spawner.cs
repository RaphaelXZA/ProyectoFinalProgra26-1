using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;

    [Header("Spawn Rate")]
    [SerializeField] private float spawnInterval = 2f;

    [Header("Spawn Rate Modifier")]
    [SerializeField] private bool modifyInterval = false;
    [SerializeField] private float intervalChangeTime = 10f;
    [SerializeField] private float intervalChangeAmount = -0.1f;

    private float spawnTimer = 0f;
    private float changeTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Spawn();
            spawnTimer = 0f;
        }

        if (modifyInterval)
        {
            changeTimer += Time.deltaTime;
            if (changeTimer >= intervalChangeTime)
            {
                ModifyInterval(intervalChangeAmount);
                changeTimer = 0f;
            }
        }
    }

    private void Spawn()
    {
        List<GameObject> available = GetAvailablePrefabs();
        if (available.Count == 0) return;

        int index = Random.Range(0, available.Count);
        Instantiate(available[index], transform.position, Quaternion.identity);
    }

    private List<GameObject> GetAvailablePrefabs()
    {
        List<GameObject> available = new List<GameObject>();

        foreach (GameObject prefab in prefabs)
        {
            PowerUpItem powerUp = prefab.GetComponent<PowerUpItem>();

            if (powerUp == null)
            {
                available.Add(prefab);
                continue;
            }

            if (ItemPool.Instance.AvailableItemIds.Contains(powerUp.powerUpId))
            {
                available.Add(prefab);
            }
        }

        return available;
    }

    public void ModifyInterval(float amount)
    {
        spawnInterval += amount;
        if (spawnInterval < 0.1f)
        {
            spawnInterval = 0.1f;
        }
    }

}