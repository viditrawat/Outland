using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        xInput = 0;
        if(comboCounter > 2 || Time.time >= lastTimeAttack + comboWindow)
            comboCounter = 0; 

        playerController.anim.SetInteger("ComboCounter", comboCounter);
        AudioManager.Instance.Play(GetAttackSfx(comboCounter));


        float attackDir = playerController.facingDir;
        
        if(xInput != 0)
            attackDir = xInput;


        playerController.SetVelocity(playerController.attackMovement[comboCounter].x * attackDir, playerController.attackMovement[comboCounter].y);
        stateTimer = 0.1f;
    }

    private Sounds GetAttackSfx(int comboCounter)
    {

        switch(comboCounter)
        {
            case 0:
                return Sounds.PlayerAttack1;
                //break;
            case 1:
                return Sounds.PlayerAttack2;
                //break;
            case 2:
                return Sounds.PlayerAttack3;
                //break;
        }

        return Sounds.PlayerAttack3;
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
