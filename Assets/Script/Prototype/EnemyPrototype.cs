using UnityEngine;

public class EnemyPrototype
{
    private readonly GameObject prefab;

    public EnemyPrototype(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public GameObject Clone(Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(prefab, position, rotation);
    }
}
