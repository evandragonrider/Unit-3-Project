using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    public GameObject enemy1Prefab;

    private Vector3[] spawnPositions = { new Vector3(8.5f, -0.5f), new Vector3(8.5f, -1.5f), new Vector3(8.5f, -3.0f) };

 



    public WordDisplay SpawnWordEnemy()
    {
        Vector3 randomPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

        GameObject parentEnemyObj = new GameObject("WordEnemyParent");

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
       GameObject enemyObj = Instantiate(enemy1Prefab, parentEnemyObj.transform);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        Debug.Log("SpawnWordEnemy called");


        Vector3 enemyOffset = new Vector3(0f, 0.5f, 0f); // adjust the offset as needed
        enemyObj.transform.position = randomPosition + enemyOffset;

        wordDisplay.SetEnemy(enemyObj);
        return wordDisplay;
    }
}