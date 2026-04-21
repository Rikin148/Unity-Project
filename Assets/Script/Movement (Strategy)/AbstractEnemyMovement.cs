using UnityEngine;

public abstract class AbstractEnemyMovement : IEnemyMovement
{
    public void Move(Transform enemy)
    {
        BeforeMove(enemy);
        PerformMovement(enemy);
        AfterMove(enemy);
    }

    protected virtual void BeforeMove(Transform enemy) { }

    protected abstract void PerformMovement(Transform enemy);

    protected virtual void AfterMove(Transform enemy) { }
}
