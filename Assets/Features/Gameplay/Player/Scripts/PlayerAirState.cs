using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
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

        if (playerController.IsWalldetected())
        {

            stateMachine.ChangeState(playerController.wallSlideState);
        }
           

        if (playerController.IsGroundDetected())
        {
            stateMachine.ChangeState(playerController.idleState);
        }
            
    
        if(xInput !=0 )
        {
            playerController.SetVelocity(playerController.moveSpeed * 0.8f * xInput, rb.velocity.y);
        }
    }
}
