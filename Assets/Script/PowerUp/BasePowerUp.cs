using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp : IPowerUp
{
    public virtual int ModifyDamage(int damage)
    {
        return damage;
    }

    public virtual int ModifyHeal(int heal)
    {
        return heal;
    }
}