using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerController playerController;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;
    public PlayerState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.playerController = _playerController;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log(animBoolName);
        playerController.anim.SetBool(animBoolName, true);
        rb = playerController.rb;
        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Debug.Log(xInput);

        playerController.anim.SetFloat("yVelocity", rb.velocity.y);
    }


    public virtual void Exit()
    {
        playerController.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishtrigger()
    {
        triggerCalled = true;
    }

}
