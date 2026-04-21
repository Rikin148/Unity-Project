using UnityEngine;

public class ZigZagMovement : AbstractEnemyMovement
{
    private float speed = 2f;
    private float amplitude = 2.5f;
    private float frequency = 2f;

    private float startX;

    protected override void PerformMovement(Transform enemy)
    {
        if (startX == 0f)
        {
            startX = enemy.position.x;
        }

        float x = startX + Mathf.Sin(Time.time * frequency * speed) * amplitude;

        enemy.position = new Vector3(x, enemy.position.y, enemy.position.z);
    }
}