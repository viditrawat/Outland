using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    #region [====== Overrides =========]
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

        if (Input.GetKeyDown(KeyCode.Q))
            stateMachine.ChangeState(playerController.counterAttackState);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(playerController.primaryAttack);

        if (!playerController.IsGroundDetected())
            stateMachine.ChangeState(playerController.airState);

        if (Input.GetKeyDown(KeyCode.Space) && playerController.IsGroundDetected())
            stateMachine.ChangeState(playerController.jumpState);
    }

    #endregion
}
