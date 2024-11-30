using System;
using UnityEngine;

public class EnemyHealthComp : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death logic here (e.g., play animation, drop loot, etc.)
        Destroy(gameObject);
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}