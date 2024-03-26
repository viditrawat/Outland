using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerController playerController;

    protected Rigidbody2D rb;

    protected float xInput;
    private string animBoolName;
    public PlayerState(PlayerController _playerController, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.playerController = _playerController;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter: " + animBoolName);
        playerController.anim.SetBool(animBoolName, true);
        rb = playerController.rb;
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        playerController.anim.SetFloat("yVelocity", rb.velocity.y);
    }


    public virtual void Exit()
    {
        Debug.Log("Exit: " + animBoolName);
        playerController.anim.SetBool(animBoolName, false);
    }

}
