using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterControl : MonoBehaviour
{

    private bool fire;

    private Player player;

    private Shooter[] shooters;

    void Start()
    {
        player = GetComponent<Player>();
        shooters = GetComponentsInChildren<Shooter>();
    }

    void Update()
    {
        if (fire)
        {
            foreach (var shooter in shooters.Where(s => s.levels.Contains(player.level)))
            {
                shooter.Fire();
            }
        }
    }

    public void OnFire(InputValue inputValue) => fire = inputValue.isPressed;
}
