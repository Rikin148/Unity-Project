using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand : ICommand
{
    private PlayerHealth playerHealth;

    public HealCommand(PlayerHealth playerHealth)
    {
        this.playerHealth = playerHealth;
    }

    public void Execute()
    {
        playerHealth.Heal(20);
    }
}