using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public GameObject enemy;
    
    private float speed;
    
    public void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        
        // Get the enemy speed from the attached enemy script
        speed = enemy.GetComponent<EnemyScript>().GetSpeed();
    }
    
    public void SetWord(string word)
    {
        textMeshPro.text = word;
    }
    
    public void SetEnemy(GameObject enemyObj)
    {
        enemy = enemyObj;
    }
    
    public void RemoveLetter()
    {
        textMeshPro.text = textMeshPro.text.Remove(0,1);
        textMeshPro.color = Color.red;
    }
    
    public void RemoveWord()
    {
        Destroy(gameObject);
    }
    
    private void Update()
    {
        if (enemy != null)
    {
        // Set position of WordDisplay object to be same as enemy position
        transform.position = enemy.transform.position - new Vector3(0f, 0.5f, 0f);

        // Get the speed from the attached enemy script
        speed = enemy.GetComponent<EnemyScript>().GetSpeed();

        // Update enemy speed
        enemy.GetComponent<EnemyScript>().SetSpeed(speed);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}

