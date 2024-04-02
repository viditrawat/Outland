using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update

    #region [======== Overrides =========]
    protected override void Start()
    {
        base.Start();
    }

    public override void Takedamage(int _damage)
    {
        base.Takedamage(_damage);
        player.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        player.Die();
    }
    #endregion


}
