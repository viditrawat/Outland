using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDeathState : EnemyState
{
    private GoblinController goblin;
    public GoblinDeathState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, GoblinController _goblin) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.goblin = _goblin;
    }


    public override void Enter()
    {
        base.Enter();

        goblin.anim.SetBool(goblin.lastAnimBoolName, true);
        goblin.anim.speed = 0;
        goblin.collider.enabled = false;
        stateTimer = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer > 0)
        {
            rb.velocity = new Vector2(0, 10);
        }
    }
}
