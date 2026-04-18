using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class AliveState : IPlayerState
{
    public void Handle(PlayerHealth player)
    {
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