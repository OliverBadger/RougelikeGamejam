using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    private AudioSource AS;
    private SpriteRenderer SR;

    private void Start() 
    {
        AS = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerStatsHandler.Instance.AddCoin();
            AS.Play();
            SR.enabled = false;
            //gameObject.active = false;
            Destroy(gameObject, AS.clip.length);
        }            
    }
}
