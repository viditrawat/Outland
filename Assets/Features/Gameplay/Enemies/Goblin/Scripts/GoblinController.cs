using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GoblinController : EnemyBase
{

    #region [======== States ==========]
    
    public GoblinIdleState idleState { get; private set; }
    public GoblinMoveState moveState { get; private set; }

    public GoblinBattleState battleState { get; private set; }
    public GoblinAttackState attackState { get; private set; }
    public GoblinDamageState damageState { get; private set; }
    
    public GoblinDeathState deathState { get; private set; }

    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new GoblinIdleState(this, stateMachine, "Idle", this);
        moveState = new GoblinMoveState(this, stateMachine, "Run", this);
        battleState = new GoblinBattleState(this, stateMachine, "Run", this);
        attackState = new GoblinAttackState(this, stateMachine, "Attack", this);
        damageState = new GoblinDamageState(this, stateMachine, "Damage", this);
        deathState = new GoblinDeathState(this, stateMachine, "Idle", this);
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
}
