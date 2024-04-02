using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();

        stateTimer = 0.4f;
        playerController.SetVelocity(5 * -playerController.facingDir, playerController.jumpFoce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(playerController.airState);

        if (playerController.IsGroundDetected())
            stateMachine.ChangeState(playerController.idleState);
    }
    #endregion
}