using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float startBound, endBound;
  

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(
            gameObject.transform.position.x  - speed,
            gameObject.transform.position.y);

             gameObject.transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name =="Enemy Boundary"){
            Destroy(gameObject);
        }

    }
  
}
