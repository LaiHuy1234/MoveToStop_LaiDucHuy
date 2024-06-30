using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    List<Character> enemy = new List<Character>();
    //check diem tiep theo co phai ground khong(1: tra ve vi tri tiep theo; 0: tra ve vi tri hien tai)
    public bool CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;
        return Physics.Raycast(nextPoint, Vector3.down, out hit, 1.5f, groundLayer);
    }


}
