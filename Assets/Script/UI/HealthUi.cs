using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    public PlayerHealth player;
    public Slider healthBar;
    public Image fillImage;

    void Start()
    {
        if (player != null)
        {
            player.OnHealthChanged += UpdateHealthBar;
            healthBar.maxValue = player.maxHP;
            healthBar.value = player.hp;
        }
    }

    void UpdateHealthBar(int hp)
    {
        if (healthBar != null)
        {
            healthBar.value = hp;
        }
        if (player.healWarningText != null && player.healWarningText.gameObject.activeSelf)
        {
            fillImage.color = Color.red;
        }
        else
        {
            fillImage.color = Color.green;
        }
    }

}