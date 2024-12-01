using Unity.VisualScripting;
using UnityEngine;

public class BossHealthBarTrigger : MonoBehaviour
{

    public GameObject bossHealthBar;
    public GameObject boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BossComp bossComp;
    void Start()
    {
        bossComp = boss.GetComponent<BossComp>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bossComp.StartAttacking();
            bossHealthBar.SetActive(true);
        }
    }
}
