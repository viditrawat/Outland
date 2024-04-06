using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageState : EnemyState
{
    private EnemyController enemy;
    public EnemyDamageState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyController _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    #region [======== Overrides =========]
    public override void Enter()
    {
        base.Enter();

        enemy.fX.InvokeRepeating("RedColorBlink", 0f, 0.1f);
        stateTimer = enemy.damageDuration;

        rb.velocity = new Vector2(-enemy.facingDir * enemy.damageDirection.x, enemy.damageDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.fX.Invoke("CancelRedBlink", 0f);
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0 )
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
    #endregion
}
