using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDamageState : EnemyState
{
    private GoblinController goblin;
    public GoblinDamageState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, GoblinController _goblin) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.goblin = _goblin;
    }


    public override void Enter()
    {
        base.Enter();

        goblin.fX.InvokeRepeating("RedColorBlink", 0f, 0.1f);
        stateTimer = goblin.damageDuration;

        rb.velocity = new Vector2(-goblin.facingDir * goblin.damageDirection.x, goblin.damageDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        goblin.fX.Invoke("CancelRedBlink", 0f);
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0 )
        {
            stateMachine.ChangeState(goblin.idleState);
        }
    }
}
