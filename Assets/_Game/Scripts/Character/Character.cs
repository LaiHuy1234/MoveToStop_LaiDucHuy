using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Character : GameUnit
{
    public Transform AttackPoint;
    public Transform WeaponHolder;
    public Weapon CurrentWeapon;
    public Vector3 TargetPosition;
    public List<Character> TargetList = new List<Character>();
    public bool IsCanMoving;
    public bool isDead;
    public int points;


    private void Start()
    {
        OnInit();

    }

    public virtual void OnInit()
    {
         
    }
    //check diem tiep theo co phai ground khong(1: tra ve vi tri tiep theo; 0: tra ve vi tri hien tai)

    public void AddTarget(Character target)
    {
        if (TargetList.Contains(target)) return;
        TargetList.Add(target);
    }

    public void RemoveTarget(Character target)
    {
        if (!TargetList.Contains(target)) return;
        TargetList.Remove(target);
    }

    public void Attack()
    {
        if (TargetList.Count > 0)
        {
            Character char1 = TargetList[0];
            Debug.Log("Da lay gia tri");
            Vector3 direction = (char1.TF.position - TF.position).normalized;
            TF.rotation = Quaternion.LookRotation(direction);
            Quaternion spawnRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 0, 0);
            CurrentWeapon = SimplePool.Spawn<Weapon>(PoolType.Axe0, WeaponHolder.position, spawnRotation);
            Debug.Log("Sinh ra riu");
            CurrentWeapon.SetTargetPosition(char1.TF.position);
        }
    }

    public void PerformAttack()
    {
        Invoke(nameof(Attack), 0.4f);
    }


}
