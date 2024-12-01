using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaComp : MonoBehaviour
{

    private float maxStamina = 100;
    private float currentStamina;
    private float staminaRegenRate = 5f;

    public Slider staminaBar;
    private void Start()
    {
        currentStamina = maxStamina;
        InvokeRepeating("RegenerateStamina", 0, 1);
        staminaBar.value = currentStamina / 100;
    }

    public bool UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina / 100;

            return true;
        }
        else return false;
    }

    void RegenerateStamina()
    {
        currentStamina += staminaRegenRate;
        staminaBar.value = currentStamina / 100;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }



}