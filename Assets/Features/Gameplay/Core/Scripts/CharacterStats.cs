using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stats strength;
    public Stats damage;
    public Stats maxHealth;

    [SerializeField] private int currentHealth;

    // Start is called before the first frame update
   protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {


        int totalDamage= damage.GetValue() + strength.GetValue();
        _targetStats.Takedamage(totalDamage);
    }

    public virtual void Takedamage(int _damage)
    {
        currentHealth -= _damage;
        Debug.Log(_damage);
        if(currentHealth <=0)
            Die();
    }
     
    protected virtual void Die()
    {
        
    }
}
