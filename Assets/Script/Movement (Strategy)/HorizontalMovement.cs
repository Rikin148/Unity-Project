using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : IEnemyMovement
{
    private float speed = 2f;
    private int direction = 1;
    private float moveRange = 8f; // how far enemy travels left/right

    public void Move(Transform enemy)
    {
        // Move horizontally
        enemy.position += Vector3.right * direction * speed * Time.deltaTime;

        // Reverse direction at boundaries
        if (enemy.position.x > moveRange)
        {
            direction = -1;
        }
        else if (enemy.position.x < -moveRange)
        {
            direction = 1;
        }
    }
}