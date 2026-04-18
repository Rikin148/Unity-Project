using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    private GameObject enemyPrefab;

    public EnemyFactory(GameObject prefab)
    {
        enemyPrefab = prefab;
    }

    public GameObject CreateEnemy(string type, Vector3 position)
    {
        // Create enemy
        GameObject enemy = Object.Instantiate(enemyPrefab, position, Quaternion.identity);

        // 🔥 Get movement controller (NOT EnemyHealth anymore)
        EnemyMovementController controller = enemy.GetComponent<EnemyMovementController>();

        // Assign movement strategy
        if (type == "zigzag")
        {
            controller.SetMovement(new ZigZagMovement());
        }
        else
        {
            controller.SetMovement(new HorizontalMovement());
        }

        return enemy;
    }
}