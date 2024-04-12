using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Entity : MonoBehaviour
{

    #region [=========== variables ============]


    protected bool isGrounded;
    protected bool isWallDetected;
    #endregion

    #region [ ========= Collision Variables =========]

    [Header("Collision Info")]
    public CapsuleCollider2D collider;
    public Transform attackCheck;
    public float attackCheckRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask groundLayer;
    #endregion

    public CharacterStats stats {  get; private set; }

    [Header("Knock Back Info")]
    [SerializeField] protected Vector2 knockBackDirection;
    [SerializeField] protected float knockBackDuration = 0.07f;
    protected bool isKnocked; 
    


    #region[====== ANimations ==========]
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region [========== Events ========]

    public Action onFlipped;
    
    #endregion

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;
    public EntityFX fX { get; private set; }

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        fX = GetComponent<EntityFX>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
    }

    protected virtual void Update()
    {

    }

    #region [ ========= velocity ==========]
    public void SetZeroVelocity()
    {
        if(isKnocked)
            return;

        rb.velocity = new Vector2(0, 0);
    }
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnocked)
            return;

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region [======= Flips ========]

    public virtual void Flip()
    {
        facingDir = facingDir * -1;
a        facingRight = !facingRight;
        transform.Rotate(0, 180f, 0);

        onFlipped?.Invoke();
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }


    #endregion

    #region [======== Actions ==========]
    public void DamageEffect()
    {
        fX.StartCoroutine(fX.FlashFX());
        StartCoroutine(HitKnockBack());
        Debug.Log(gameObject.name + "Was damaged");
    }

    protected virtual IEnumerator HitKnockBack()
    {
        isKnocked = true;
        rb.velocity = new Vector2(knockBackDirection.x * -facingDir, knockBackDirection.y);
        yield return new WaitForSeconds(knockBackDuration);
        isKnocked = false;
    }

    public virtual void Die()
    {

    }

    
    #endregion

    #region [======= Getters ========]
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    public virtual bool IsWalldetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundLayer);
    #endregion

    #region[ ========= Gizmos ==========]

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

}
