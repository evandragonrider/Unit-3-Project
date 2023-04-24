using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Script : EnemyScript
{
    private bool isThrowingLetter = false; // flag to indicate if enemy is currently throwing letter
    private float throwInterval = 10f; // interval between each throw
    private float throwTime = 0f; // time since last throw

    public GameObject letterPrefab; // reference to letter prefab
    public Transform letterSpawnPoint; // reference to transform where the letter will spawn

    void Start()
    {
        // Set the speed for this enemy
        SetSpeed(0.0009f);
         letterSpawnPoint = transform;
          InvokeRepeating("StartThrowingLetter", 0f, throwInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isThrowingLetter)
        {
            // enemy is not throwing letter, move as usual
            Vector2 newPos = new Vector2(
                gameObject.transform.position.x - GetSpeed(),
                gameObject.transform.position.y);

            gameObject.transform.position = newPos;

            // check if it's time to throw letter
            throwTime += Time.deltaTime;
            if (throwTime >= throwInterval)
            {
                throwTime = 0f;
                isThrowingLetter = true;

                // set a delay before the enemy starts throwing
                float delay = 0f;
                Invoke("StartThrowingLetter", delay);
            }
        }
    }

    void StartThrowingLetter()
    {
        // spawn the letter projectile at the designated spawn point
        GameObject letter = Instantiate(letterPrefab, transform.position, Quaternion.identity);

     letter.GetComponent<LetterProjectile>().SetSpeed(GetSpeed());

        // set a delay before the enemy stops throwing
        float throwDuration = 2f;
        Invoke("StopThrowingLetter", throwDuration);
    }

    void StopThrowingLetter()
    {
        isThrowingLetter = false;
    }
}
