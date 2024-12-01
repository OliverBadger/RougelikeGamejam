using System.Collections;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private AudioSource AS;
    private SpriteRenderer SR;
    public GameObject EnemyPrefab;
    public GameObject[] SpawnPoints;

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

            for(int i = 0; i <= (SpawnPoints.Length * 2); i++)
            {
                int randomNum = Random.Range(0,SpawnPoints.Length);
                Debug.Log($"The random number is: {randomNum}");
                Debug.Log($"The spawnpoint details are: {SpawnPoints[randomNum]}");
                Instantiate(EnemyPrefab, SpawnPoints[randomNum].transform);
            }
        }
    }
}
