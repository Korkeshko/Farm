using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Move(new Vector2(horizontal, vertical));
    }
}
