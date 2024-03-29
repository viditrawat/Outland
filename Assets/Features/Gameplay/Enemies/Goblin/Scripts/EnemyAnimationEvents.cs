using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    [SerializeField] private GoblinController enemy;

    public void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }

}
