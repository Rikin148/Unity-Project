using UnityEngine;

public class HorizontalMovement : AbstractEnemyMovement
{
    private float speed = 2f;
    private int direction = 1;
    private float moveRange = 8f;

    protected override void PerformMovement(Transform enemy)
    {
        enemy.position += Vector3.right * direction * speed * Time.deltaTime;

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