using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int hp;

    public int maxHeals = 3;
    private int currentHeals;

    public TextMeshProUGUI healWarningText;
    private IPlayerState currentState;

    public List<Image> healIcons;

    public event Action<int> OnHealthChanged;

    // 🔥 DECORATOR SYSTEM
    private IPowerUp powerUp = new BasePowerUp();

    // 🔥 Cooldowns
    private float shieldCooldown = 0f;
    private float damageCooldown = 0f;

    // 🔥 Active timers
    private float shieldTimer = 0f;
    private float damageTimer = 0f;

    private bool isShieldActive = false;
    private bool isDamageActive = false;

    void Start()
    {
        hp = maxHP;
        currentHeals = maxHeals;
        currentState = new AliveState();

        if (healWarningText != null)
        {
            healWarningText.gameObject.SetActive(false);
        }

        CheckLowHealth();
        OnHealthChanged?.Invoke(hp);
    }

    void Update()
    {
        currentState?.Handle(this);

        // 🔥 Cooldowns
        if (shieldCooldown > 0)
            shieldCooldown -= Time.deltaTime;

        if (damageCooldown > 0)
            damageCooldown -= Time.deltaTime;

        // 🔥 Shield active
        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;

            if (shieldTimer <= 0)
            {
                isShieldActive = false;
                powerUp = new BasePowerUp();
                Debug.Log("Shield Ended");
            }
        }

        // 🔥 Damage active
        if (isDamageActive)
        {
            damageTimer -= Time.deltaTime;

            if (damageTimer <= 0)
            {
                isDamageActive = false;
                powerUp = new BasePowerUp();
                Debug.Log("Double Damage Ended");
            }
        }

        // 🔥 E → Shield (10 sec cooldown)
        if (Input.GetKeyDown(KeyCode.E) && shieldCooldown <= 0)
        {
            ApplyShield();
            shieldTimer = 10f;
            isShieldActive = true;
            shieldCooldown = 10f;

            Debug.Log("Shield Activated (10s)");
        }

        // 🔥 Q → Double Damage (60 sec cooldown)
        if (Input.GetKeyDown(KeyCode.Q) && damageCooldown <= 0)
        {
            ApplyDoubleDamage();
            damageTimer = 10f;
            isDamageActive = true;
            damageCooldown = 60f;

            Debug.Log("Double Damage Activated (10s)");
        }
    }

    public void SetState(IPlayerState newState)
    {
        currentState = newState;
    }

    public void TakeDamage(int damage)
    {
        damage = powerUp.ModifyDamage(damage);

        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            OnHealthChanged?.Invoke(hp);
            GameOver();
            return;
        }

        CheckLowHealth();
        OnHealthChanged?.Invoke(hp);
    }

    public void Heal(int amount)
    {
        if (currentHeals <= 0)
        {
            Debug.Log("No heals left!");
            return;
        }

        if (hp >= maxHP)
        {
            Debug.Log("Already at full health!");
            return;
        }

        amount = powerUp.ModifyHeal(amount);

        hp += amount;

        if (hp > maxHP)
            hp = maxHP;

        int index = currentHeals - 1;

        if (index >= 0 && index < healIcons.Count)
        {
            healIcons[index].gameObject.SetActive(false);
        }

        currentHeals--;

        CheckLowHealth();
        OnHealthChanged?.Invoke(hp);
    }

    void CheckLowHealth()
    {
        int threshold = Mathf.RoundToInt(maxHP * 0.3f);

        if (hp <= threshold)
        {
            ShowHealWarning();
        }
        else
        {
            HideHealWarning();
        }
    }

    public void ShowHealWarning()
    {
        if (healWarningText != null)
        {
            healWarningText.gameObject.SetActive(true);
        }
    }

    public void HideHealWarning()
    {
        if (healWarningText != null)
        {
            healWarningText.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    // 🔥 DECORATOR METHODS

    public void ApplyShield()
    {
        powerUp = new ShieldPowerUp();
    }

    public void ApplyDoubleDamage()
    {
        powerUp = new DoubleDamagePowerUp();
    }

    // 🔥 UI GETTERS

    public float GetShieldCooldown()
    {
        return shieldCooldown;
    }

    public float GetHealCooldown() // still used by UI (Q ability)
    {
        return damageCooldown;
    }

    public bool IsShieldActive()
    {
        return isShieldActive;
    }

    public bool IsHealActive() // reused for Q ability
    {
        return isDamageActive;
    }
}