using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsHandler : MonoBehaviour
{
    public static PlayerStatsHandler Instance;
    public event Action<int> OnSpeedChanged;


    [Header("Combat Stats")]
    public int projectileDamage;
    public int projectileVelocity;

    [Header("Movement Stats")]
    private int _speed;
    public int speed
    {
        get => _speed;
        set 
        {
            _speed = value;
            OnSpeedChanged?.Invoke(_speed);
        } 
    }

    [Header("Player Stats")]
    public int maxHealth;
    public int currentHealth;
    public int totalCoins;
    public bool isDead;

    [Header("UI Settings")]
    public Canvas canvas;
    public Slider slider;
    public TextMeshProUGUI coinDisplay;


    public void Die()
    {
        isDead = true;
    }

    public void Live()
    {
        isDead = false;
    }

    private void Awake(){
        if (Instance == null) { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
        }
        else
            Destroy(gameObject);

        speed = 5;

        currentHealth = maxHealth;

        // Set UI Fields
        coinDisplay.text = totalCoins.ToString();
        slider.value = currentHealth;
    }

    public void AddCoin()
    {
        totalCoins++;
        coinDisplay.text = totalCoins.ToString();
    }

    public void PlayerTakesDamage(int damage)
    {
        if (currentHealth > 0)
        {
            slider.value = currentHealth;
            currentHealth -= damage;
        }
    }

    public void AddSpeed(int amount)
    {
        speed += amount;
    }
}
