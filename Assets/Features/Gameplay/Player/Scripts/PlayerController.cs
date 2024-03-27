using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.TextCore;

public class PlayerController : MonoBehaviour
{
    #region [ ============ Attack Variables ==========]
    [Header("Attack Details")]
    public Vector2[] attackMovement;
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
    public int facingDir { get; private set; } = 1;
    private bool facingRight = true;

    #endregion

    #region [ ========= Collision Variables =========]

    [Header("Collision Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundLayer;
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


    #endregion

    #region[====== ANimations ==========]
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region [======= Getters ========]
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    public bool IsWalldetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundLayer) && !IsGroundDetected();
    #endregion

    #region [ ========== Init ===========]
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");

        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Init(idleState);
    }

    #endregion

    

    private void Update()
    {
        stateMachine.currentState.Update();

        CheckForDashInput();

    }

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

    public void Animationtrigger() => stateMachine.currentState.AnimationFinishtrigger();



    #region [====== Couroutines ========]

    public IEnumerator BusyFor(float _sec)
    {
        isBusy = true;
        yield return new WaitForSeconds(_sec);

        isBusy = false;
    }

    #endregion

    #region [ ========= velocity ==========]
    public void ZeroVelocity()
    {
        rb.velocity = new Vector2 (0, 0);
    }
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region [======= Flips ========]

    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180f, 0);
    }

    public void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if(_x < 0 && facingRight) 
            Flip();
    }


    #endregion





    #region[ ========= Gizmos ==========]

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));

    }
    #endregion
}
