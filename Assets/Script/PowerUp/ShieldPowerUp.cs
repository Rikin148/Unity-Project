using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : BasePowerUp
{
    public override int ModifyDamage(int damage)
    {
        return damage / 2; 
    }
}