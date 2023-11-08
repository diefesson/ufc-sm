using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooterRotator : MonoBehaviour
{
    public GameObject gunpoint;

    private Vector2 move;

    private Vector2 aim;

    private Vector2 direction;

    void Start()
    {
        direction = new Vector2(0, 1);
    }

    void Update()
    {
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

    public void OnMove(InputValue value) => move = value.Get<Vector2>();

    public void OnAim(InputValue value) => aim = value.Get<Vector2>();
}
