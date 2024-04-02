using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : GoblinGroundedState
{
    public GoblinIdleState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, GoblinController _goblin) : base(_enemyBase, _stateMachine, _animBoolName, _goblin)
    {
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();
        stateTimer = goblin.idleTime;
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
            stateMachine.ChangeState(goblin.moveState);
        }
           
    }

    #endregion
}
