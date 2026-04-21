using UnityEngine;

public class ShieldPowerUp : PowerUpDecorator
{
    public ShieldPowerUp(IPowerUp inner) : base(inner) { }

    public override int ModifyDamage(int damage)
    {
        return wrapped.ModifyDamage(damage) / 2;
    }
}