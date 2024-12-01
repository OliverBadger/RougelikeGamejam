using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthComp : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private Animator animator;
    public bool isBoss;
    public Slider bossHealthBar;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        if (isBoss)
        {
            bossHealthBar.value = currentHealth / maxHealth;

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (isBoss)
        {
            bossHealthBar.value = currentHealth / maxHealth;
        }
        animator.SetTrigger("IsDamaged");
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }



    public float GetCurrentHealth()
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