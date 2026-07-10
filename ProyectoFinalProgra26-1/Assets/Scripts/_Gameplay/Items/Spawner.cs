using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;

    [Header("Cadencia")]
    [SerializeField] private float spawnInterval = 2f;

    [Header("Modificador de cadencia")]
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
        if (prefabs.Count == 0) return;

        int index = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[index], transform.position, Quaternion.identity);
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