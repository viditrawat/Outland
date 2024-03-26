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

        if (rb.velocity.y == 0)
            stateMachine.ChangeState(playerController.idleState);
    }
}
