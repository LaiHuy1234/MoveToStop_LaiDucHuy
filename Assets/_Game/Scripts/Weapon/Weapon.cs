using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameUnit
{
    [SerializeField] private Character owner;
    private Vector3 targetPosition;
    //private float speed = 10f;

    private void Update()
    {
        //Vector3 newPosition = Vector3.MoveTowards(TF.position, targetPosition, speed * Time.deltaTime);
        //TF.position = new Vector3(newPosition.x, 0.5f, newPosition.z);
        //if (this.poolType == PoolType.Bullet_1 || this.poolType == PoolType.Bullet_2)
        //{
        //    TF.Rotate(Vector3.back, 800f * Time.deltaTime, Space.Self);
        //}
        //// Kiểm tra khoảng cách giữa Weapon và targetPosition
        //if (Vector3.Distance(TF.position, targetPosition) < 0.1f)
        //{
        //    OndDespawn();
        //}
    }

    public void SetOwner(Character character)
    {
        character = owner;
    }

    public void SetTargetPosition(Vector3 newTargetPosition)
    {
        targetPosition = new Vector3(newTargetPosition.x, 0.5f, newTargetPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        ColliderWithCharacter(other);
    }

    private void ColliderWithCharacter(Collider other)
    {
        if (!other.CompareTag(Constants.TAG_CHARACTER)) return;
        Character character = CacheCollider.GetComponentFromCache<Character>(other);
    }
}
