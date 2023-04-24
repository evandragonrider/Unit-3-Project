using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterProjectile : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private float speed = 0.01f;

    public void Start(){
         textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    // Set the speed of the projectile
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void SetLetter(string letter)
    {
        textMeshPro.text = letter;
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
    void Update()
    {
        // Move the projectile
        Vector2 newPos = new Vector2(
            gameObject.transform.position.x - speed,
            gameObject.transform.position.y);

        gameObject.transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Enemy Boundary")
        {
            Destroy(gameObject);
        }
    }
}
