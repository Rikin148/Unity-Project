using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth player;

    public Slider healthBar;
    public Image fillImage;

    // 🔥 NEW: heal UI
    public TextMeshProUGUI healText;

    void Start()
    {
        if (player != null)
        {
            // 🔥 Subscribe to events
            player.OnHealthChanged += UpdateHealthBar;
            player.OnHealChanged += UpdateHealUI;

            // Setup health bar
            healthBar.maxValue = player.maxHP;

            // 🔥 FORCE INITIAL UPDATE
            UpdateHealthBar(player.hp);
            UpdateHealUI(player.GetHealCharges());
        }
    }

    void UpdateHealthBar(int hp)
    {
        if (healthBar != null)
        {
            healthBar.value = hp;
        }

        if (fillImage != null && player != null)
        {
            float hpPercent = hp / (float)player.maxHP;

            if (hpPercent <= 0.3f)
            {
                fillImage.color = Color.red;
            }
            else
            {
                fillImage.color = Color.green;
            }

            // Optional smooth color:
            // fillImage.color = Color.Lerp(Color.red, Color.green, hpPercent);
        }
    }

    // 🔥 NEW FUNCTION FOR HEAL UI
    void UpdateHealUI(int charges)
    {
        if (healText != null)
        {
            healText.text = "Q: " + charges;
        }
    }
}