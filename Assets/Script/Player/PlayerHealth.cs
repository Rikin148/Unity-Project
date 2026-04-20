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
    public Action<int> OnHealChanged;

    private IPowerUp powerUp = new BasePowerUp();

    private float shieldCooldown = 0f;
    private float damageCooldown = 0f;

    private float shieldTimer = 0f;
    private float damageTimer = 0f;

    private bool isShieldActive = false;
    private bool isDamageActive = false;

    public GameOverUI gameOverUI;

    void Start()
    {
        hp = maxHP;
        currentHeals = maxHeals;
        currentState = new AliveState();

        if (healWarningText != null)
            healWarningText.gameObject.SetActive(false);

        CheckLowHealth();

        OnHealthChanged?.Invoke(hp);
        OnHealChanged?.Invoke(currentHeals);
    }

    void Update()
    {
        currentState?.Handle(this);

        if (shieldCooldown > 0) shieldCooldown -= Time.deltaTime;
        if (damageCooldown > 0) damageCooldown -= Time.deltaTime;

        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0)
            {
                isShieldActive = false;
                powerUp = new BasePowerUp();
            }
        }

        if (isDamageActive)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                isDamageActive = false;
                powerUp = new BasePowerUp();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && shieldCooldown <= 0)
        {
            ApplyShield();
            shieldTimer = 10f;
            isShieldActive = true;
            shieldCooldown = 10f;
        }

        if (Input.GetKeyDown(KeyCode.Q) && damageCooldown <= 0)
        {
            ApplyDoubleDamage();
            damageTimer = 10f;
            isDamageActive = true;
            damageCooldown = 60f;
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
            SetState(new DeadState());
            return;
        }

        CheckLowHealth();
        OnHealthChanged?.Invoke(hp);
    }

    public void Heal(int amount)
    {
        if (currentHeals <= 0) return;
        if (hp >= maxHP) return;

        hp += amount;
        if (hp > maxHP) hp = maxHP;

        int index = currentHeals - 1;

        if (index >= 0 && index < healIcons.Count)
        {
            healIcons[index].gameObject.SetActive(false);
        }

        currentHeals--;

        OnHealChanged?.Invoke(currentHeals);
        OnHealthChanged?.Invoke(hp);

        CheckLowHealth();
    }

    public int GetHealCharges()
    {
        return currentHeals;
    }

    void CheckLowHealth()
    {
        int threshold = Mathf.RoundToInt(maxHP * 0.3f);

        if (hp <= threshold)
            ShowHealWarning();
        else
            HideHealWarning();
    }

    public void ShowHealWarning()
    {
        if (healWarningText != null)
            healWarningText.gameObject.SetActive(true);
    }

    public void HideHealWarning()
    {
        if (healWarningText != null)
            healWarningText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameObject.SetActive(false);

        if (gameOverUI != null)
            gameOverUI.ShowGameOver(GameManager.Instance.level);

        Time.timeScale = 0f;
    }

    public void ResetPlayer()
    {
        Debug.Log("ResetPlayer called");

        hp = maxHP;
        currentHeals = maxHeals;

        // 🔥 FIX: Restore heal icons
        foreach (Image icon in healIcons)
        {
            if (icon != null)
                icon.gameObject.SetActive(true);
        }

        gameObject.SetActive(true);

        currentState = new AliveState();

        shieldCooldown = 0f;
        damageCooldown = 0f;
        shieldTimer = 0f;
        damageTimer = 0f;

        isShieldActive = false;
        isDamageActive = false;

        powerUp = new BasePowerUp();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.simulated = true;
        }

        PlayerMovement move = GetComponent<PlayerMovement>();
        if (move != null) move.enabled = true;

        PlayerShooting shoot = GetComponent<PlayerShooting>();
        if (shoot != null) shoot.enabled = true;

        HideHealWarning();

        OnHealthChanged?.Invoke(hp);
        OnHealChanged?.Invoke(currentHeals);

        Debug.Log("Player reset complete");
    }

    public void ApplyShield()
    {
        powerUp = new ShieldPowerUp();
    }

    public void ApplyDoubleDamage()
    {
        powerUp = new DoubleDamagePowerUp();
    }

    public float GetShieldCooldown()
    {
        return shieldCooldown;
    }

    public float GetHealCooldown()
    {
        return damageCooldown;
    }

    public bool IsShieldActive()
    {
        return isShieldActive;
    }

    public bool IsHealActive()
    {
        return isDamageActive;
    }
}