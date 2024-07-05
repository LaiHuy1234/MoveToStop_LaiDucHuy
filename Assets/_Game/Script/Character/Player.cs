using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    public bool isMoving = false;

    private void Start()
    {
        OnInit();
    }

    public override void OnInit()
    {
        base.OnInit();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        Vector3 direction = Joystick.direct;
        if (direction.magnitude >= 0.1f)
        {
            Move(direction);
        }
    }

    public void Move(Vector3 direction)
    {
        TF.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), speed * Time.deltaTime);
        TF.Translate(direction * speed * Time.deltaTime, Space.World);
        isMoving = true;
    }
}

