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
}
