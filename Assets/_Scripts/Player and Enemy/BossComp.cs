using UnityEngine;
using UnityEngine.UI;

public class BossComp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject electricBall;
    public Slider bossHealthBar;
    public bool BossTriggerHit;


    // Update is called once per frame
    void ElectricBallAttack()
    {
        Debug.Log("Boss is attacking with electric ball");
        Instantiate(electricBall, transform.position, Quaternion.identity);
    }

    public void StartAttacking()
    {
        InvokeRepeating("ElectricBallAttack", 1, 2);
    }

}
