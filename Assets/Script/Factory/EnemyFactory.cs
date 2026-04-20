using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    private GameObject enemyPrefab;

    // 🔥 Add reference to facade
    private GameFacade facade;

    public EnemyFactory(GameObject prefab, GameFacade facadeRef)
    {
        enemyPrefab = prefab;
        facade = facadeRef;
    }

    public GameObject CreateEnemy(string type, Vector3 position)
    {
        // Create enemy
        GameObject enemy = Object.Instantiate(enemyPrefab, position, Quaternion.identity);

        // 🔥 Get movement controller
        EnemyMovementController controller = enemy.GetComponent<EnemyMovementController>();

        if (controller != null)
        {
            if (type == "zigzag")
                controller.SetMovement(new ZigZagMovement());
            else
                controller.SetMovement(new HorizontalMovement());
        }

        // 🔥 REGISTER WITH FACADE (IMPORTANT)
        if (facade != null && enemy != null)
        {
            facade.RegisterEnemy(enemy);
        }

        return enemy;
    }
}