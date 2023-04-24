using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Script : EnemyScript
{
void Start()
    {
        // Set the speed for this enemy
        SetSpeed(0.0009f);
    }
    // Start is called before the first frame update
    public override float GetSpeed()
    {
        return base.GetSpeed();
    }

    public override void SetSpeed(float newSpeed)
    {
        base.SetSpeed(newSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(
            gameObject.transform.position.x - GetSpeed(),
            gameObject.transform.position.y);

        gameObject.transform.position = newPos;
    }
}
