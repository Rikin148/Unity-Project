using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IPlayerState
{
    public void Handle(PlayerHealth player)
    {
        player.GameOver();
    }
}