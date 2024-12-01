using UnityEngine;

public class EnemyDamageComp : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enemy collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy attacking player");
            other.gameObject.GetComponent<PlayerHealthComp>().TakeDamage(damage);
        }
    }
}