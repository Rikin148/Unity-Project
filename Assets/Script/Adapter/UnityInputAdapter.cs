using System.Collections;
using System.Collections.Generic;
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
}