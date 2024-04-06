using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundedState : EnemyState
{
    protected EnemyController enemy;
    protected Transform player;
    public EnemyGroundedState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyController _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(base.enemBase.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
    #endregion
}
