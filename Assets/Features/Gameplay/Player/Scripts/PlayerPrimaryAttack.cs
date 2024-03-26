using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int comboCounter;
    private float lastTimeAttack;
    private float comboWindow = 2f;
    public PlayerPrimaryAttack(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(comboCounter > 2 || Time.time >= lastTimeAttack + comboWindow)
            comboCounter = 0;

        playerController.anim.SetInteger("ComboCounter", comboCounter);
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;

        lastTimeAttack = Time.time;

    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            stateMachine.ChangeState(playerController.idleState);
    }
}
