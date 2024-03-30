using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerController, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = playerController.counterAttackDuration;
        playerController.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        playerController.SetZeroVelocity();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerController.attackCheck.position, playerController.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<EnemyBase>() != null && hit.GetComponent<EnemyBase>().CanBeDamage())
            {
                stateTimer = 10f;
                playerController.anim.SetBool("SuccessfulCounterAttack", true);
                
            }
                
        }

        if(stateTimer < 0 || triggerCalled)
        {
            stateMachine.ChangeState(playerController.idleState);
        }
    }
}
