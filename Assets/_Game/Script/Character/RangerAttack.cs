using UnityEngine;

public class RangerAttack : MonoBehaviour
{

    [SerializeField] private Character owner;
    [SerializeField] private Weapon weaponPrefab;


    private void OnTriggerEnter(Collider other)
    {
        AddTargetToTargetList(other);
        AttackTarget(other);
        
    }

    private void AddTargetToTargetList(Collider other)
    {
        if (!other.CompareTag(Constants.TAG_CHARACTER)) return;
        Character target1 = other.GetComponent<Character>();
        owner.AddTarget(target1);
    }

    private void AttackTarget(Collider other)
    {
        Character target = other.GetComponent<Character>();
        target.Attack();
    }


    private void OnTriggerExit(Collider other)
    {
        RemoveTargetFromTargetList(other);
    }

    private void RemoveTargetFromTargetList(Collider other)
    {
        if (!other.CompareTag(Constants.TAG_CHARACTER)) return;
        Character target1 = other.GetComponent<Character>();
        owner.RemoveTarget(target1);
    }
}
