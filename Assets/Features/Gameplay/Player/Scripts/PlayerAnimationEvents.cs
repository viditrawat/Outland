using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;


    public void AnimationTrigger()
    {
        playerController.Animationtrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerController.attackCheck.position, playerController.attackCheckRadius);

        foreach(var hit in colliders)
        {
            if (hit.GetComponent<EnemyBase>() != null)
            {
                EnemyStats target = hit.GetComponent<EnemyStats>();
                playerController.stats.DoDamage(target);
                   
            }
                
        }
    }
}
