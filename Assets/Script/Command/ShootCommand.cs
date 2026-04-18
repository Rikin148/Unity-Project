using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    private Transform firePoint;

    public ShootCommand(Transform firePoint)
    {
        this.firePoint = firePoint;
    }

    public void Execute()
    {
        GameObject bullet = PlayerBulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.SetActive(true);
    }
}