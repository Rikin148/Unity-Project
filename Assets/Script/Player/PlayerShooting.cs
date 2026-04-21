using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;

    private IInputAdapter inputAdapter;
    private ICommand shootCommand;
    private ICommand healCommand;

    void Awake()
    {
        inputAdapter = new UnityInputAdapter();
    }

    void Start()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        shootCommand = new ShootCommand(firePoint);
        healCommand = new HealCommand(playerHealth);
    }

    void Update()
    {
        if (inputAdapter.ShootPressed())
        {
            shootCommand.Execute();
        }

        if (inputAdapter.HealPressed())
        {
            healCommand.Execute();
        }
    }
}