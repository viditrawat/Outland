using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected EnemyController enemyController;

    protected bool triggerCalled;
    private string animBoolName;
    protected float stateTimer;

    public EnemyState(EnemyController _enemyController, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemyController = _enemyController;
        this.stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = true;
        enemyController.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        triggerCalled = false;
        enemyController.anim.SetBool(animBoolName, false);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
}
