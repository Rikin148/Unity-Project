using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;

    private ICommand shootCommand;
    private ICommand healCommand;

    void Start()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        shootCommand = new ShootCommand(firePoint);
        healCommand = new HealCommand(playerHealth);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootCommand.Execute();
        }

        if (Input.GetMouseButtonDown(1))
        {
            healCommand.Execute();
        }
    }
}