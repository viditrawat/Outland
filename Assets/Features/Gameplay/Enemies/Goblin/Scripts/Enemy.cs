using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Entity
{

    [SerializeField] protected LayerMask playerMask;


    [Header("Damage Info")]
    public float damageDuration;
    public Vector2 damageDirection;
    protected bool canBeDamage;
    [SerializeField] protected GameObject counterImage;

    public float moveSpeed = 2f;
    public float idleTime = 1f;
    public float battleTime = 2f;

    [Header("Attack Info")]
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;
    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();


    }

    public virtual void OpenCounterAttackWindw()
    {
        canBeDamage = true;
        counterImage.SetActive(true);
    }

    public virtual void CloseCounterAttackWindow()
    {
        canBeDamage = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanBeDamage()
    {
        if(canBeDamage)
        {
            CloseCounterAttackWindow();
            return true;
        }

        return false;
    }

    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, playerMask);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x * attackDistance * facingDir, transform.position.y));
    }

}
