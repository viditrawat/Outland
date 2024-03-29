using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttack;
    private float comboWindow = 2f;
    public PlayerPrimaryAttackState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(comboCounter > 2 || Time.time >= lastTimeAttack + comboWindow)
            comboCounter = 0; 

        playerController.anim.SetInteger("ComboCounter", comboCounter);


        float attackDir = playerController.facingDir;
        
        if(xInput != 0)
            attackDir = xInput;


        playerController.SetVelocity(playerController.attackMovement[comboCounter].x * attackDir, playerController.attackMovement[comboCounter].y);
        stateTimer = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();

        playerController.StartCoroutine("BusyFor", 0.15f);
        comboCounter++;

        lastTimeAttack = Time.time;

    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            playerController.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(playerController.idleState);
    }
}
