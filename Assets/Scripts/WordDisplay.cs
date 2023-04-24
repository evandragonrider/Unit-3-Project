using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject enemy;
    public TextMeshProUGUI textMeshPro;
    public float Movespeed = 1f;
    public int fontSize =16;
    public Color textColor = Color.white;

    public void Start(){
        textMeshPro=GetComponent<TextMeshProUGUI>();
    }
    public void SetWord (string word){
        textMeshPro.text = word;
    }
    public void SetEnemy(GameObject enemyObj)
{
    enemy = enemyObj;
}
    public void RemoveLetter(){
        textMeshPro.text = textMeshPro.text.Remove(0,1);
        textMeshPro.color = Color.red;
    }
    public void RemoveWord(){
        Destroy(gameObject);
    }
    private void Update(){
        transform.Translate(-Movespeed * Time.deltaTime, 0f, 0f);
    if (enemy != null)
    {
        enemy.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
    }
    }
   }
