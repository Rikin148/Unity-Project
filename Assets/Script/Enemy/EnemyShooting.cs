using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float fireRate = 2f;
    private float nextFireTime = 0f;

    public Transform firePoint;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = EnemyBulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.SetActive(true);
    }
}