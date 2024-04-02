using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    
    public Stats strength;
    public Stats maxHealth;
    public Stats damage;
    public int currentHealth;

    public Action onHealthChanged;

    #region [ ========= Initialization ======]
    protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();
    }

    #endregion



    #region [ ======== Damage =========]

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

    protected virtual void Die()
    {

    }

    #endregion


    #region [ ========== Getters =========]
    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue();
    }
    #endregion


}
