using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    private Vector3[] spawnPositions = { new Vector3(8.5f, -0.5f), new Vector3(8.5f, -1.5f), new Vector3(8.5f, -3.0f) };

 
    private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log(collision.gameObject.name);
    if (collision.gameObject.name == "Enemy Boundary")
    {
        // Check if the collided object is a child of "WordEnemyParent"
        Transform parent = collision.gameObject.transform.parent;
        if (parent != null && parent.gameObject.name == "WordEnemyParent")
        {
            // Destroy the "WordEnemyParent" GameObject
            Destroy(parent.gameObject);
        }
    }
}



    public WordDisplay SpawnWordEnemy()
    {
        Vector3 randomPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
        GameObject[] enemies = { enemy1Prefab, enemy2Prefab, enemy3Prefab };
        GameObject spawningEnemy = enemies[Random.Range(0, enemies.Length)];
        GameObject parentEnemyObj = new GameObject("WordEnemyParent");

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
       GameObject enemyObj = Instantiate(spawningEnemy, parentEnemyObj.transform);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        Debug.Log("SpawnWordEnemy called");


        Vector3 enemyOffset = new Vector3(0f, 0.5f, 0f); // adjust the offset as needed
        enemyObj.transform.position = randomPosition + enemyOffset;

        wordDisplay.SetEnemy(enemyObj);
        return wordDisplay;

       

    }
  
    }

