using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerController.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(xInput == playerController.facingDir && playerController.IsWalldetected())
            return;


        if (xInput != 0 && !playerController.isBusy ) 
        {
            stateMachine.ChangeState(playerController.moveState);
        } 
    }
}
