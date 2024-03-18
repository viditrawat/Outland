using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private WarriorController warriorController;


    public void AnimationTrigger()
    {
        warriorController.AttackOver();
    }
}
