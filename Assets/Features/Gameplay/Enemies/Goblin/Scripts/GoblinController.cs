using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GoblinController : Entity
{
    private bool isAttacking;
    #region [=========== variables ============]
    [Header("Movement Info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    #endregion


    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask playerLayerMask;

    private RaycastHit2D isPlayerDetected;
    protected override void Update()
    {
        base.Update();

        if(isPlayerDetected)
        {
            if(isPlayerDetected.distance > 1)
            {
                rb.velocity = new Vector2(moveSpeed * 1.5f * facingDir, rb.velocity.y);
                isAttacking = false;
            }
            else
            {
                isAttacking = true;
            }
        }

        if (!isGrounded || isWallDetected)
            Flip();

        if(!isAttacking)
            rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
    }

    protected override void CollisionChecks()
    {
        base.CollisionChecks();

        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, playerLayerMask);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDir, transform.position.y));

    }
}
