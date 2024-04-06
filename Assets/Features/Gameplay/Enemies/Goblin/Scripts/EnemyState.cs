using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected EnemyBase enemBase;
    protected Rigidbody2D rb;

    protected bool triggerCalled;
    private string animBoolName;
    protected float stateTimer;

    public EnemyState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemBase = _enemyBase;
        this.stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemBase.rb;
        enemBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        
        enemBase.anim.SetBool(animBoolName, false);
        enemBase.AssignLastAnimName(animBoolName);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
