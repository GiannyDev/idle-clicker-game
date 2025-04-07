using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private Transform spawnPos;
    
    // Start is called before the first frame update
    private void Start()
    {
        SpawnCloud();
    }

    private void SpawnCloud()
    {
        GameObject newCloud = Instantiate(cloudPrefab, spawnPos.position, Quaternion.identity);
        Cloud cloud = newCloud.GetComponent<Cloud>();
        cloud.SpawnPosition = spawnPos.position;
    }
}
