using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed;

    public virtual float GetSpeed()
    {
        return speed;
    }

    public virtual void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Enemy Boundary")
        {
            Destroy(gameObject);
        }
    }
}