using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMoveState : GoblinGroundedState
{
    public GoblinMoveState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, GoblinController _goblin) : base(_enemyBase, _stateMachine, _animBoolName, _goblin)
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
        goblin.SetVelocity(goblin.moveSpeed * goblin.facingDir, rb.velocity.y);

        Debug.Log("IsWallDetecetd : " + goblin.IsWalldetected() + ", Is ground Detected:  " + goblin.IsGroundDetected());

        if(goblin.IsWalldetected() || !goblin.IsGroundDetected())
        {
            goblin.Flip();
            stateMachine.ChangeState(goblin.idleState);
        }
    }
    #endregion
}
