using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    public override void AnimationFinishtrigger()
    {
        base.AnimationFinishtrigger();
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
        playerController.SetZeroVelocity();
    }
}
