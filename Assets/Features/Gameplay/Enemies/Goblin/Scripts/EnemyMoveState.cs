using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyGroundedState
{
    public EnemyMoveState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyController _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

        Debug.Log("IsWallDetecetd : " + enemy.IsWalldetected() + ", Is ground Detected:  " + enemy.IsGroundDetected());

        if(enemy.IsWalldetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
    #endregion
}
