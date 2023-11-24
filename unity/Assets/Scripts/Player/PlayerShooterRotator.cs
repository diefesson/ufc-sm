using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooterRotator : MonoBehaviour
{
    public GameObject gunpoint;

    private PlayerInputActions inputActions;
    private Vector2 direction;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    void Start()
    {
        direction = new Vector2(0, 1);
    }

    void Update()
    {
        var move = inputActions.Gameplay.Move.ReadValue<Vector2>();
        var aim = inputActions.Gameplay.Aim.ReadValue<Vector2>();
        if (aim != Vector2.zero)
        {
            direction = aim;
        }
        else if (move != Vector2.zero)
        {
            direction = move;
        }
        gunpoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
