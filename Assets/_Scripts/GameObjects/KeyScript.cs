using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private AudioSource AS;
    private SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameManager.KeyPickedUp();
            AS.Play();
            SR.enabled = false;
            Destroy(gameObject, AS.clip.length);
        }    
    }
}
