using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LowHealthState : IPlayerState
{
    public void Handle(PlayerHealth player)
    {
       
        player.ShowHealWarning();

        if (player.hp <= 0)
        {
            player.SetState(new DeadState());
        }
        else if (player.hp >= 30)
        {
            player.SetState(new AliveState());
        }
    }
}