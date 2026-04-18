using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamagePowerUp : BasePowerUp
{
    public override int ModifyDamage(int damage)
    {
        return damage * 2; // 🔥 DOUBLE DAMAGE
    }
}