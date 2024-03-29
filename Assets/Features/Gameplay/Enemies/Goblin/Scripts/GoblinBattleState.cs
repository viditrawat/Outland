using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBattleState : EnemyState
{
    private Transform player;
    private GoblinController goblin;
    private int moveDir;
    public GoblinBattleState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, GoblinController _goblin) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.goblin = _goblin;
    }

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

        if(enemy.IsPlayerDetected())
        {
            stateTimer = goblin.battleTime;

            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if(CanAttack())
                    stateMachine.ChangeState(goblin.attackState);
               
            }
                
        }
        else
        { 
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, goblin.transform.position) > 10)
            {
                stateMachine.ChangeState(goblin.idleState);
            }
        }

        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else if(player.position.x < enemy.transform.position.x)
            moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }

    private bool CanAttack()
    {
        if(Time.time >= goblin.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        Debug.Log("Attack is on cooldown");
        return false;
    }
}

