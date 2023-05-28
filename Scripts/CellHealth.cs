using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHealth : MonoBehaviour
{
    
    public float cellHealth;
    public GameObject foodPrefab;
    public float spawnRadius = 1f;
    public float spawnDelay = 10f;
    public int maxFoodSpawn = 5;
    private int foodSpawned = 0;
    private float lastSpawnTime = 0f;
    public GameObject cellPrefab;
    public float cellSpawnRadius = 1f;
    public int maxCellSpawn = 2;
    private int cellSpawned = 0;
    public float reproductionEnergy = 0;
    public GameObject cellEaterPrefab;
    public float maxHealth = 50;
    void Start()
    {
        
    }

    
    void Update()
    {
        cellHunger();
        cellSpawn();
    }

    public void cellHunger()
    {
        if (cellHealth > 0)
        {
            cellHealth -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Cell"))
        {
            if (other.CompareTag("Food") )
            {
                cellHealth += 5;
                reproductionEnergy += 1;
                Destroy(other.gameObject);
                spawnFood();
            }
        }
        else if (gameObject.CompareTag("CellEater"))
        {
            if (other.CompareTag("Cell") )
            {
                cellHealth += 5;
                reproductionEnergy += 1;
                Destroy(other.gameObject);
                spawnFood();
            }
            else if (other.CompareTag("Food") )
            {
                cellHealth += 0.5f;
                reproductionEnergy += 1;
                Destroy(other.gameObject);
                spawnFood();
            }
        }
        
    }

    private void spawnFood()
    {
        float currentTime = Time.time;

        if (foodSpawned < maxFoodSpawn && (currentTime - lastSpawnTime) > spawnDelay)
        {
            Vector2 spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(foodPrefab, (Vector2)transform.position + spawnPos, Quaternion.identity);

            foodSpawned = 0;
            lastSpawnTime = currentTime;
        }
    }
    
    private void cellSpawn()
    {
        float currentTime = Time.time;
        int spawnDetermine = Random.Range(0,2);
        if (spawnDetermine == 0)
        {
            if (cellHealth > 20 && cellSpawned < maxCellSpawn && reproductionEnergy == 10) // (currentTime - lastSpawnTime) > spawnDelay &&
            {
                Vector2 spawnPos = Random.insideUnitCircle.normalized * cellSpawnRadius;
                GameObject newCell = Instantiate(cellPrefab, (Vector2)transform.position + spawnPos, Quaternion.identity);
                newCell.GetComponent<CellHealth>().cellHealth = 5;
                newCell.GetComponent<CellHealth>().reproductionEnergy = 0;
                cellSpawned = 0; //++
                reproductionEnergy = 0;
                lastSpawnTime = currentTime;
            }
        }
        else if (spawnDetermine == 1)
        {
           if (cellHealth > 20 && cellSpawned < maxCellSpawn && reproductionEnergy == 10) // (currentTime - lastSpawnTime) > spawnDelay &&
            {
                Vector2 spawnPos = Random.insideUnitCircle.normalized * cellSpawnRadius;
                GameObject newEaterCell = Instantiate(cellEaterPrefab, (Vector2)transform.position + spawnPos, Quaternion.identity);
                newEaterCell.GetComponent<CellHealth>().cellHealth = 5;
                newEaterCell.GetComponent<CellHealth>().reproductionEnergy = 0;
                cellSpawned = 0; //++
                reproductionEnergy = 0;
                lastSpawnTime = currentTime;
            } 
        }
    }

}
