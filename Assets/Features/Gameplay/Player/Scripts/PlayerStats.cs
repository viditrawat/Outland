using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void Takedamage(int _damage)
    {
        base.Takedamage(_damage);
        player.DamageEffect();
    }


}
