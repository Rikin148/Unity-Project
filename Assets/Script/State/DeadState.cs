using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IPlayerState
{
    private bool hasDied = false;

    public void Handle(PlayerHealth player)
    {
        
        if (!hasDied)
        {
            hasDied = true;

            Debug.Log("DeadState Triggered");

            player.GameOver();
        }
    }
}