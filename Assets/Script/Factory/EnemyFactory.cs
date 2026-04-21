using UnityEngine;

public class EnemyFactory
{
    private readonly EnemyPrototype enemyPrototype;
    private GameFacade facade;

    public EnemyFactory(GameObject prefab, GameFacade facadeRef)
    {
        enemyPrototype = new EnemyPrototype(prefab);
        facade = facadeRef;
    }

    public GameObject CreateEnemy(string type, Vector3 position)
    {
        GameObject enemy = enemyPrototype.Clone(position, Quaternion.identity);

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