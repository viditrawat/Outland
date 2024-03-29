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
    
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new GoblinIdleState(this, stateMachine, "Idle", this);
        moveState = new GoblinMoveState(this, stateMachine, "Run", this);
        battleState = new GoblinBattleState(this, stateMachine, "Run", this);
        attackState = new GoblinAttackState(this, stateMachine, "Attack", this);
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
}
