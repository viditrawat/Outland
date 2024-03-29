using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected EnemyBase enemy;

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
        triggerCalled = true;
        enemy.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        triggerCalled = false;
        enemy.anim.SetBool(animBoolName, false);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
}
