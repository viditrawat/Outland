using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    #region [====== Overrides =========]

    public override void Enter()
    {
        base.Enter();

        stateTimer = playerController.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        playerController.SetVelocity(0, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        if(!playerController.IsGroundDetected() && playerController.IsWalldetected())
            stateMachine.ChangeState(playerController.wallSlideState);
        playerController.SetVelocity(playerController.dashSpeed * playerController.dashDir, 0f);
        if (stateTimer < 0)
            stateMachine.ChangeState(playerController.idleState);
    }

    #endregion
}
