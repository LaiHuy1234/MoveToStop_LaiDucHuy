using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Character : GameUnit
{
    [SerializeField] Weapon weaponPrefab;
    [SerializeField] private Transform attackPoint;
    public Vector3 target;
    public List<Character> targetList = new List<Character>();
    

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
        if (targetList.Contains(target)) return;    
        targetList.Add(target);
    }

    public void RemoveTarget(Character target)
    {
        if (!targetList.Contains(target)) return;
        targetList.Remove(target);
    }

    public void Attack()
    {
        if (targetList.Count > 0) return;
        {
            Character char1 = targetList[0];
            if (char1 = null)
            {
                return;
            }
            Vector3 direction = (char1.TF.position - TF.position).normalized;
            TF.rotation = Quaternion.LookRotation(direction);
            Quaternion spawnRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 0, 0);
            Weapon weaponObject = SimplePool.Spawn<Weapon>(weaponPrefab.poolType, attackPoint.position, spawnRotation);
            weaponObject.SetOwner(this);
        }
    }

    public void SetTarget(Vector3 nextPoint)
    {
        target = nextPoint;
    }

    
}
