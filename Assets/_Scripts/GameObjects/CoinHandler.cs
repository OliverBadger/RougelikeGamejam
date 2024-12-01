using System.Collections;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
        private AudioSource AS; // Audio source for coin pickup sound
    private SpriteRenderer SR; // Sprite renderer for visual representation

    [Header("Pop-Up Animation")]
    public float popHeight = 2f; // Height of the pop-up
    public float popDuration = 0.5f; // Duration of the pop-up animation
    private bool canBePickedUp = false; // Pickup state

    private void Start()
    {
        // Get required components
        AS = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();

        // Start the pop-out animation
        StartCoroutine(PopOut());
    }

    private IEnumerator PopOut()
    {
        Vector3 startPosition = transform.position; // Initial position
        Vector3 peakPosition = startPosition + Vector3.up * popHeight; // Peak position during pop-up

        // Animate upwards
        float elapsed = 0f;
        while (elapsed < popDuration / 2f)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, peakPosition, elapsed / (popDuration / 2f));
            yield return null;
        }

        // Animate downwards
        elapsed = 0f;
        while (elapsed < popDuration / 2f)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(peakPosition, startPosition, elapsed / (popDuration / 2f));
            yield return null;
        }

        // Enable picking up after animation is complete
        canBePickedUp = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Check if the colliding object is the player and the coin is pick-upable
        if (canBePickedUp && other.CompareTag("Player"))
        {
            // Add coin to player stats
            PlayerStatsHandler.Instance.AddCoin();

            // Play pickup sound
            AS.Play();

            // Hide the coin sprite immediately
            SR.enabled = false;

            // Destroy the coin object after the sound finishes playing
            Destroy(gameObject, AS.clip.length);
        }
    }
}
