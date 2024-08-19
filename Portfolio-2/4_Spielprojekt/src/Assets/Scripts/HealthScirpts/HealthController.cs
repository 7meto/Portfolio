using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float currentHealth;
    
    [SerializeField]
    private float maxHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    public UnityEvent OnHealthGained;

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }
        
        if (IsInvincible)
        {
            return ;
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += amountToAdd;

        OnHealthChanged.Invoke();
        OnHealthGained.Invoke();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    
}
