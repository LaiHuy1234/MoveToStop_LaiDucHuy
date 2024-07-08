using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    public bool IsMoving;

    private void Start()
    {
        OnInit();
    }

    public override void OnInit()
    {
        base.OnInit();

        // lay id mu khi bang UserDataManager
        // tu id vu khi lay ra duoc Prefab hoac la kieu weapon tuong ung
        // tu weapon se spawn weapon
        CurrentWeapon = SimplePool.Spawn<Weapon>(PoolType.Axe0, WeaponHolder.position, Quaternion.identity);
        CurrentWeapon.SetOwner(this);
        CurrentWeapon.TF.SetParent(WeaponHolder);
    }

    private void Update()
    {
        CheckInput();
        IsMoving = CheckIsMoving();
        if (IsMoving) return;
            Attack();
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
        IsMoving = true;
    }

    public bool CheckIsMoving() => joystick.Vertical == 0 && joystick.Horizontal == 0;

}

