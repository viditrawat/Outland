using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class WarriorController : MonoBehaviour
{

    private float XInput;


    #region [========== Components ==========]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LayerMask groundMask;
    #endregion

    #region [=========== variables ============]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;
    private bool isGrounded = true;

    [Header("Dash Info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;


    [Header("Attack Info")]
    private bool isAttacking;
    private int comboCounter;
    private float comboTimeWindow;
    [SerializeField] private float comboTime = 0.3f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        XInput = Input.GetAxisRaw("Horizontal");
        CollisionChecks();

        dashTime -= Time.deltaTime;
        comboTimeWindow -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashTime = dashDuration;
        }


       // FlipController();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }


        //attacking
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }


        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isDashing", dashTime > 0);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetInteger("ComboCounter", comboCounter);

    }

    private void StartAttackEvent()
    {
        if (!isGrounded) return;

        if (comboTimeWindow < 0)
            comboCounter = 0;
        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);


    }

    private void Movement()
    {
        if (isAttacking)
            return;
        if(dashTime > 0)
        {
            rb.velocity = new Vector2(XInput * dashSpeed, 0);    
        }
        else
        {
            rb.velocity = new Vector2(XInput * moveSpeed, rb.velocity.y);
        }
        
        animator.SetBool("isMoving", rb.velocity.x != 0);
        spriteRenderer.flipX = rb.velocity.x < 0;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));        
    }

    #region [========== Animation Events =============]
    public void AttackOver()
    {
        isAttacking = false;
        comboCounter++;
        if (comboCounter > 2)
            comboCounter = 0;

    }
    
    #endregion

}
