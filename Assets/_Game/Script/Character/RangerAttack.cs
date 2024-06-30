using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : Character
{
    [SerializeField] private Character owner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //if(enemy.Count)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
