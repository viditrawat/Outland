using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

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

        playerController.SetVelocity(xInput * playerController.moveSpeed, rb.velocity.y);

        if (xInput == 0 || playerController.IsWalldetected())
        {
            stateMachine.ChangeState(playerController.idleState);
        }
    }
}
