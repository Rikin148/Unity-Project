using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveState : IPlayerState
{
    public void Handle(PlayerHealth player)
    {
       
        // 🔥 ENSURE PLAYER IS ACTIVE
        if (!player.gameObject.activeSelf)
        {
            player.gameObject.SetActive(true);
        }

        player.HideHealWarning();

        if (player.hp <= 0)
        {
            player.SetState(new DeadState());
        }
        else if (player.hp < 30)
        {
            player.SetState(new LowHealthState());
        }
    }
}