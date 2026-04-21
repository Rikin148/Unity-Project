using UnityEngine;

public class UnityInputAdapter : IInputAdapter
{
    public bool ShootPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool HealPressed()
    {
        return Input.GetMouseButtonDown(1);
    }

    public bool ShieldAbilityPressed()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool DoubleDamageAbilityPressed()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }
}