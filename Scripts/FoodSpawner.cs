using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public float spawnInterval = 3f; // The interval at which food will spawn
    public int numFoodToSpawn = 100; // The number of food items to spawn initially
    public float xRange = 20f; // The x range within which food will spawn
    public float yRange = 20f; // The y range within which food will spawn
    public GameObject cellPrefab;
    public int numberOfCells;

    // Start is called before the first frame update
    void Start()
    {
        
        float x = Random.Range(-1, 2);
        float y = Random.Range(-1, 2);
        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(cellPrefab, spawnPos, Quaternion.identity);

        
        // Spawn the initial set of food items
        for (int i = 0; i < numFoodToSpawn; i++)
        {
            SpawnFood();
        }

        
    
        
        // Start the coroutine to spawn food items every spawnInterval seconds
        StartCoroutine(SpawnFoodRoutine());
        
    }

    IEnumerator SpawnFoodRoutine()
    {
        while (true)
        {
            // Wait for spawnInterval seconds
            yield return new WaitForSeconds(spawnInterval);

            // Spawn a food item
            SpawnFood();
        }
    }


    void SpawnFood()
    {
        // Generate a random position within the specified range
        float x = Random.Range(-xRange, xRange);
        float y = Random.Range(-yRange, yRange);
        Vector3 spawnPos = new Vector3(x, y, 0f);

        // Instantiate the food prefab at the random position
        Instantiate(foodPrefab, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        // Find all instances of the cell prefab in the scene
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");
        GameObject[] Eatercells = GameObject.FindGameObjectsWithTag("CellEater");

        // Count the number of cells
        numberOfCells = cells.Length + Eatercells.Length;

        if (numberOfCells == 0)
        {
            SpawnCell();
        }
        
    }

    void SpawnCell()
    {
        // Generate a random position within the specified range
        float x = Random.Range(-1, 2);
        float y = Random.Range(-1, 2);
        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(cellPrefab, spawnPos, Quaternion.identity);
    }
}
