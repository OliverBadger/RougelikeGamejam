using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthComp : MonoBehaviour
{
    public Canvas activeCanvas;
    public Canvas deathCanvas;
    public float maxHealth = 100;
    private float currentHealth;
    private bool isDead;
    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth / maxHealth;
        Debug.Log(healthBar.value);
        if (currentHealth <= 0 && !PlayerStatsHandler.Instance.isDead)
        {
            Die();
            PlayerStatsHandler.Instance.Live();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        // Handle player death
        Debug.Log("Player died!");
        // Add additional logic for player death here

        activeCanvas.enabled = false;
        deathCanvas.enabled = true;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}