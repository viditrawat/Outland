using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected EnemyBase enemy;
    protected Rigidbody2D rb;

    protected bool triggerCalled;
    private string animBoolName;
    protected float stateTimer;

    public EnemyState(EnemyBase _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemyBase;
        this.stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemy.rb;
        enemy.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        
        enemy.anim.SetBool(animBoolName, false);
        enemy.AssignLastAnimName(animBoolName);
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
