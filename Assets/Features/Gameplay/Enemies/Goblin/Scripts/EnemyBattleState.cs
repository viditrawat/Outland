using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleState : EnemyState
{
    private Transform player;
    private EnemyController enemy;
    private int moveDir;
    public EnemyBattleState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyController _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(base.enemBase.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;

            if(base.enemBase.IsPlayerDetected().distance < base.enemBase.attackDistance)
            {
                if(CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
               
            }
                
        }
        else
        { 
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 10)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }

        if (player.position.x > base.enemBase.transform.position.x)
            moveDir = 1;
        else if(player.position.x < base.enemBase.transform.position.x)
            moveDir = -1;

        base.enemBase.SetVelocity(base.enemBase.moveSpeed * moveDir, rb.velocity.y);
    }

    private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttacked + base.enemBase.attackCooldown)
        {
            base.enemBase.lastTimeAttacked = Time.time;
            return true;
        }
        Debug.Log("Attack is on cooldown");
        return false;
    }
    #endregion
}

