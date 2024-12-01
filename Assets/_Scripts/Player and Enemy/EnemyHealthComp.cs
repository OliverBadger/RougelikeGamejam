using System;
using System.Collections;
using UnityEngine;

public class EnemyHealthComp : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("IsDamaged");
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    IEnumerator Die()
    {
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);

    }
}