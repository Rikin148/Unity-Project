using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float speed = 6f;
    public float lifeTime = 3f;

    private float timer;

    void OnEnable()
    {
        // 🔥 Reset timer every time bullet is reused
        timer = lifeTime;
    }

    void Update()
    {
        // 🔥 Move downward
        transform.position += Vector3.down * speed * Time.deltaTime;

        // 🔥 Countdown lifetime
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            gameObject.SetActive(false); // return to pool
        }
    }

    // 🔥 COLLISION WITH PLAYER
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) return;

        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(15);
            }

            gameObject.SetActive(false);
        }
    }
}