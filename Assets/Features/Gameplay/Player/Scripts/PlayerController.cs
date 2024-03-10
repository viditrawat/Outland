using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region [========== variables ==========]

    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float jumpForce = 7.5f;
    [SerializeField] private float rollForce = 6.0f;


    private bool isWallSliding = false;
    private bool grounded = false;
    private bool rolling = false;
    private int facingDirection = 1;
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    private float delayToIdle = 0.0f;
    private float rollDuration = 8.0f / 14.0f;
    private float rollCurrentTime;

    #endregion

    #region [======= Components ============]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Sensor_HeroKnight groundSensor;
    [SerializeField] private Sensor_HeroKnight wallSensorR1;
    [SerializeField] private Sensor_HeroKnight wallSensorR2;
    [SerializeField] private Sensor_HeroKnight wallSensorL1;
    [SerializeField] private Sensor_HeroKnight wallSensorL2;

    #endregion



    void Update()
    {
        SetTimers();
        SetStates();
        float horizontal = UnityEngine.Input.GetAxis("Horizontal");
        CheckForPlayerMovement();

        MovePlayer(horizontal);
        Jump();
        Attack();
    }

    private void SetStates()
    {
        // Disable rolling if timer extends duration
        if (rollCurrentTime > rollDuration)
            rolling = false;

        //Check if character just landed on the ground
        if (!grounded && groundSensor.State())
        {
            grounded = true;
            animator.SetBool("Grounded", grounded);
        }

        //Check if character just started falling
        if (grounded && !groundSensor.State())
        {
            grounded = false;
            animator.SetBool("Grounded", grounded);
        }
    }

    private void SetTimers()
    {
        // Increase timer that controls attack combo
        timeSinceAttack += Time.deltaTime;

        // Increase timer that checks roll duration
        if (rolling)
            rollCurrentTime += Time.deltaTime;
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && timeSinceAttack > 0.25f && !rolling)
        {
            currentAttack++;

            // Loop back to one after third attack
            if (currentAttack > 3)
                currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            animator.SetTrigger("Attack" + currentAttack);

            // Reset timer
            timeSinceAttack = 0.0f;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space") && grounded && !rolling)
        {
            animator.SetTrigger("Jump");
            grounded = false;
            animator.SetBool("Grounded", grounded);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            groundSensor.Disable(0.2f);
        }
    }

    private void CheckForPlayerMovement()
    {
        if (!grounded && groundSensor.State())
        {
            grounded = true;
            animator.SetBool("Grounded", grounded);
        }

        //Check if character just started falling
        if (grounded && !groundSensor.State())
        {
            grounded = false;
            animator.SetBool("Grounded", grounded);
        }
    }

    private void MovePlayer(float horizontal)
    {
        if (horizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            facingDirection = 1;
        }

        else if (horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            facingDirection = -1;
        }

        if (!rolling)
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        animator.SetFloat("AirSpeedY", rb.velocity.y);

        if (Mathf.Abs(horizontal) > Mathf.Epsilon)
        {
            // Reset timer
            delayToIdle = 0.05f;
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            // Prevents flickering transitions to idle
            delayToIdle -= Time.deltaTime;
            if (delayToIdle < 0)
                animator.SetInteger("AnimState", 0);
        }
    }
}
