using UnityEngine;

public class PlayerStaminaComp : MonoBehaviour
{

    private float maxStamina = 100;
    private float currentStamina;
    private float staminaRegenRate = 5f;
    private void Start()
    {
        currentStamina = maxStamina;
        InvokeRepeating("RegenerateStamina", 0, 1);
    }

    public bool UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            return true;
        }
        else return false;
    }

    void RegenerateStamina()
    {
        currentStamina += staminaRegenRate;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }
    void Update()
    {
        Debug.Log("Current Stamina: " + currentStamina);
    }


}