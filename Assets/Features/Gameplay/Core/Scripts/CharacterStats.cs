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

    public int currentHealth;

    public Action onHealthChanged;

    // Start is called before the first frame update
   protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {


        int totalDamage= damage.GetValue() + strength.GetValue();
        _targetStats.Takedamage(totalDamage);
    }

    public virtual void Takedamage(int _damage)
    {
        DecreaseHealth(_damage);
        Debug.Log(_damage);
        if(currentHealth <=0)
            Die();

    }

    protected virtual void DecreaseHealth(int _damage)
    {
        currentHealth -= _damage;

        onHealthChanged?.Invoke();
    }

    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue();
    }
     
    protected virtual void Die()
    {
        
    }
}
