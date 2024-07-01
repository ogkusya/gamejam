using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour, IDamageable
{
    [SerializeField] private DamageableType damageableType;
    [SerializeField] protected int maxHealth;

    [SerializeField]protected int currentHealth;

    public int CurrentHealth => currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        OnAwake();
      
    }

    protected virtual void OnAwake()
    {
    }

    public virtual void Initialize()
    {
        currentHealth = maxHealth;
        gameObject.SetActive(true);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthUpdated();
    }

    public virtual void TakeHeal(int heal)
    { 
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        HealthUpdated();
    }


    public void UpdateCurrentHealth(int health)
    {
        currentHealth = health;
    }
    protected virtual void HealthUpdated()
    {
        if (currentHealth > 0)
        {
            return;
        }
    }
}

public enum DamageableType
{
    player,
    enemy,
}
