using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private EnemyController goblin;
    public EnemyAttackState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyController _goblin) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.goblin = _goblin;
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        enemBase.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemBase.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(goblin.battleState);
    }
    #endregion
}
