using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private EnemyBase enemy;

    #region [======== Overrides =========]
    protected override void Start()
    {
        base.Start();
    }

    public override void Takedamage(int _damage)
    {
        base.Takedamage(_damage);
        enemy.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        enemy.Die();
    }
    #endregion

}

