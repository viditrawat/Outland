using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : EnemyState
{
    GoblinController goblin;
    public GoblinIdleState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, GoblinController _goblin) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.goblin = _goblin;
    }

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
            Debug.Log("Enter Move state");
            stateMachine.ChangeState(goblin.moveState);
        }
           
    }
}
