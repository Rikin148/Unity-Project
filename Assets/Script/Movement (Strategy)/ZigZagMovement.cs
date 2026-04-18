using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZigZagMovement : IEnemyMovement
{
    private float speed = 2f;
    private float amplitude = 2.5f;   // width of zigzag
    private float frequency = 2f;     // how fast it oscillates

    private float startX;

    public void Move(Transform enemy)
    {
        // Store starting position once
        if (startX == 0f)
        {
            startX = enemy.position.x;
        }

        // Zigzag movement using sine wave
        float x = startX + Mathf.Sin(Time.time * frequency * speed) * amplitude;

        enemy.position = new Vector3(x, enemy.position.y, enemy.position.z);
    }
}