using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    private IEnemyMovement movementStrategy;

    public void SetMovement(IEnemyMovement movement)
    {
        movementStrategy = movement;
    }

    void Update()
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move(transform);
        }
    }
}