using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerStatsHandler.Instance.AddCoin();
        Destroy(gameObject);    
    }
}
