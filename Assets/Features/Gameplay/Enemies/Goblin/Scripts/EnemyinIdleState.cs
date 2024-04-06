using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyinIdleState : EnemyGroundedState
{
    public EnemyinIdleState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyController _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
           
    }

    #endregion
}
