using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Character : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    public Vector3 target;


    public List<Character> targetList = new List<Character>();


    //check diem tiep theo co phai ground khong(1: tra ve vi tri tiep theo; 0: tra ve vi tri hien tai)
    public bool CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;
        return Physics.Raycast(nextPoint, Vector3.down, out hit, 1.5f, groundLayer);
    }

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
            char1.transform.position = target;
        }
    }

    public void SetTarget(Vector3 nextPoint)
    {
        target = nextPoint;
    }
}
