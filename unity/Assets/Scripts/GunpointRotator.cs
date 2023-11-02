using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunpointRotator : MonoBehaviour
{
    public GameObject gunpoint;

    public float deadzone;

    private float distance;

    private Vector2 move;

    private Vector2 aim;

    private Vector2 direction;

    void Start()
    {
        distance = gunpoint.transform.position.magnitude;
        direction = new Vector2(0, 1);
    }

    public void OnMove(InputValue value) => move = value.Get<Vector2>();

    public void OnAim(InputValue value) => aim = value.Get<Vector2>();

    void Update()
    {
        if (deadzone < aim.magnitude)
        {
            direction = aim.normalized;
        }
        else if (deadzone < move.magnitude)
        {
            direction = move.normalized;
        }
        gunpoint.transform.position = this.transform.position + new Vector3(direction.x, direction.y, 0) * distance;
        gunpoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
