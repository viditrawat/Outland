using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyController : EnemyBase
{

    #region [======== States ==========]
    
    public EnemyinIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }

    public EnemyBattleState battleState { get; private set; }
    public EnemyAttackState attackState { get; private set; }
    public EnemyDamageState damageState { get; private set; }
    
    public EnemyDeathState deathState { get; private set; }

    #endregion

    #region [======== Overrides =========]
    protected override void Awake()
    {
        base.Awake();
        idleState = new EnemyinIdleState(this, stateMachine, "Idle", this);
        moveState = new EnemyMoveState(this, stateMachine, "Run", this);
        battleState = new EnemyBattleState(this, stateMachine, "Run", this);
        attackState = new EnemyAttackState(this, stateMachine, "Attack", this);
        damageState = new EnemyDamageState(this, stateMachine, "Damage", this);
        deathState = new EnemyDeathState(this, stateMachine, "Idle", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override bool CanBeDamage()
    {
        if(base.CanBeDamage())
        {
            stateMachine.ChangeState(damageState);
            return true;
        }
        return false;
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
    }
    #endregion
}
