using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 3f;

    private float timer;

    void OnEnable()
    {
        timer = lifeTime; // reset every time bullet is reused
    }

    void Update()
    {
        // Move bullet upward
        transform.position += Vector3.up * speed * Time.deltaTime;

        // Lifetime countdown
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            gameObject.SetActive(false); // 🔥 pool instead of destroy
        }
    }

    // 🔥 COLLISION (PLAYER BULLET HITS ENEMY)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(15);
            }

            gameObject.SetActive(false); // 🔥 THIS STOPS IT
        }
    }
}