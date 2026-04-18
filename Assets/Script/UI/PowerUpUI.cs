using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    public PlayerHealth player;

    public TextMeshProUGUI shieldStatus;
    public TextMeshProUGUI healStatus;

    public Image shieldIcon;
    public Image healIcon;

    private float pulseSpeed = 4f;

    void Update()
    {
        // 🛡️ SHIELD
        if (player.IsShieldActive())
        {
            shieldStatus.text = "<color=#00FFFF>E <size=70%>ACTIVE</size></color>";
            shieldIcon.color = Color.white;
        }
        else if (player.GetShieldCooldown() > 0)
        {
            shieldStatus.text = Mathf.Ceil(player.GetShieldCooldown()).ToString();
            shieldIcon.color = Color.gray;
        }
        else
        {
            shieldStatus.text = "E";
            shieldIcon.color = Color.white;
        }

        // ⚔️ DAMAGE (Q)
        if (player.IsHealActive())
        {
            healStatus.text = "<color=#FF4C4C>Q <size=70%>ACTIVE</size></color>";
            healIcon.color = Color.white;
        }
        else if (player.GetHealCooldown() > 0)
        {
            healStatus.text = Mathf.Ceil(player.GetHealCooldown()).ToString();
            healIcon.color = Color.gray;
        }
        else
        {
            healStatus.text = "Q";
            healIcon.color = Color.white;
        }
    }
}