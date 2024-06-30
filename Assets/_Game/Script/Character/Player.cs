using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }



    private void Move()
    {
        // Check Input
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Convert Vector3

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        if (moveDirection != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            // Check if the player is on the ground
            Vector3 nextPoint = transform.position + transform.forward * speed * Time.deltaTime;
            if (nextPoint != Vector3.zero)
            {
                if (CheckGround(nextPoint))
                {
                    // If the player is on the ground, move them
                    rb.MovePosition(nextPoint);
                }
            }
        }

    }

}
