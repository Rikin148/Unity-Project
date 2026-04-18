using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 50;
    public int hp;

    public Slider healthBar;
    public GameObject worldCanvas;

    private bool isDead = false; // 🔥 prevents multiple death calls

    void Start()
    {
        hp = maxHP;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHP;
            healthBar.value = hp;
        }
    }

    // 🔥 DAMAGE SYSTEM
    public void TakeDamage(int damage)
    {
        if (isDead) return; // 🚨 CRITICAL FIX

        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            Die();
            return;
        }

        // Update health bar if still alive
        if (healthBar != null)
        {
            healthBar.value = hp;
        }
    }

    // 🔥 DEATH HANDLING
    void Die()
    {
        isDead = true;

        // Update UI
        if (healthBar != null)
        {
            healthBar.value = 0;
        }

        if (worldCanvas != null)
        {
            Destroy(worldCanvas);
        }

        // Notify GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.EnemyDied();
        }

        // Destroy enemy
        Destroy(gameObject);
    }
}