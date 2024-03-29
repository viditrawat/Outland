using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GoblinController : EnemyBase
{

    #region [======== States ==========]
    
    public GoblinIdleState idleState { get; private set; }
    public GoblinMoveState moveState { get; private set; }
    
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new GoblinIdleState(this, stateMachine, "Idle", this);
        moveState = new GoblinMoveState(this, stateMachine, "Run", this);

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
