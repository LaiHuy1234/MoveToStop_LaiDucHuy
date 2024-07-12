using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    private float time;
    private float idleDuration = 1f;

    public void OnEnter(Bot enemy)
    {
        enemy.StopMoving();
        time = 0;
    }

    public void OnExecute(Bot enemy)
    {
        time += Time.deltaTime;
        if (time >= idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Bot enemy)
    {
        enemy.StopMoving();
    }
}
