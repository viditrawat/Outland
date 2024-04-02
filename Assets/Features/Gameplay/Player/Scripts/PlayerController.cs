using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.TextCore;

public class PlayerController : Entity
{
    #region [ ============ Attack Variables ==========]
    [Header("Attack Details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = 0.2f;

    public bool isBusy {  get; private set; }

    #endregion
    #region[ ========== Movement Variables ============]
    [Header("Move Info")]
    public float moveSpeed = 12f;
    public float jumpFoce = 5f;
    [Header("Dash Info")]
    [SerializeField] private float dashCooldown = 1f;
    private float dashUsageTimer = 1f;
    public float dashSpeed = 20f;
    public float dashDuration = 1f;
    public float dashDir {  get; private set; }


    #endregion

    #region [======== States =========]
    public PlayerStateMachine stateMachine {  get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    public PlayerJumpState jumpState { get; private set; }

    public PlayerAirState airState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerDashState dashState { get; private set; }

    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set; }

    public PlayerCounterAttackState counterAttackState { get; private set; }
    
    public PlayerDeathState deathState { get; private set; }

    #endregion

    #region [ ========== Init ===========]
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");

        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttackState = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
        deathState = new PlayerDeathState(this, stateMachine, "Die");
    
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Init(idleState);
    }

    #endregion

    public void Animationtrigger() => stateMachine.currentState.AnimationFinishtrigger();

    #region [ ======== Overrides =========]
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

        CheckForDashInput();

    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
    }
    #endregion


    private void CheckForDashInput()
    {
        if (IsWalldetected())
            return;

        dashUsageTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = facingDir;

            stateMachine.ChangeState(dashState);

        }
        
    }




    #region [====== Couroutines ========]

    public IEnumerator BusyFor(float _sec)
    {
        isBusy = true;
        yield return new WaitForSeconds(_sec);

        isBusy = false;
    }

    #endregion









}
