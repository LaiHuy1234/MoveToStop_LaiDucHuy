using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using static UnityEngine.GraphicsBuffer;


public class Bot : Character
{
        [SerializeField] private float movementSpeed = 3.5f; // Tốc độ di chuyển của Bot
        [SerializeField] private NavMeshAgent agent;
        private IState<Bot> currentState;

        private void Start()
        {
            OnInit();
        }

        public override void OnInit()
        {
            base.OnInit();
            agent = GetComponent<NavMeshAgent>();
            agent.speed = movementSpeed;
            currentState = new IdleState();
            currentState.OnEnter(this);
        }

        private void Update()
        {
            if (!isDead)
            {
                BotBehavior();
            }
        }

        private void BotBehavior()
        {
            //currentState.OnExecute(this);
        }

        public void ChangeState(IState<Bot> state)
        {
            if (currentState != null)
            {
                currentState.OnExit(this);
            }

            currentState = state;

            if (currentState != null)
            {
                currentState.OnEnter(this);
            }
        }

        public void StopMoving()
        {
            agent.isStopped = true;
            IsCanMoving = false;
        }

        //public void MoveBot()
        //{
        //    Character nearestCharacter = FindNearestCharacter();
        //    if (nearestCharacter != null)
        //    {
        //        agent.isStopped = false;
        //        agent.SetDestination(nearestCharacter.TF.position);
        //        IsMoving = true;
        //    }
        //}

        //public Character FindNearestCharacter()
        //{
        //    Character nearestCharacter = null;
        //    float minDistance = float.MaxValue;

        //    foreach (Character character in LevelManager.Ins.currentMap.activeCharacters)
        //    {
        //        if (character != this) // Không tính chính Bot này
        //        {
        //            float distance = Vector3.Distance(transform.position, character.transform.position);
        //            if (distance < minDistance)
        //            {
        //                minDistance = distance;
        //                nearestCharacter = character;
        //            }
        //        }
        //    }

        //    return nearestCharacter;
        //}

        public Character FindBigCharacter()
        {
            var listChar = LevelManager.Ins.currentMap.activeCharacters;
            Character characterWithMaxPoints = listChar.OrderByDescending(c => c.points).FirstOrDefault();
            return characterWithMaxPoints;
        }

        internal void MoveStop()
        {
            agent.enabled = false;
        }

    public void RandomOutfit()
    {
        // Lay ngau nhien 1 id bat ki
        // Tu id do se sinh ra vu khi tren tay
        // CurrentWeapon = 
    }
}
