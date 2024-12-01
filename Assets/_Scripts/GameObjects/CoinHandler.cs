using System.Collections;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
private AudioSource AS; // Audio source for coin pickup sound
    private SpriteRenderer SR; // Sprite renderer for visual representation

    [Header("Pop-Up Animation")]
    public float popHeight = 2f; // Height of the pop-up
    public float popDuration = 0.5f; // Duration of the pop-up animation
    public float horizontalRange = 2f; // Maximum horizontal distance (left or right)
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
        Vector3 startPosition = transform.position;

        // Determine a random horizontal offset (left or right)
        float randomHorizontalOffset = Random.Range(-horizontalRange, horizontalRange);

        // Calculate the target peak and end positions
        Vector3 peakPosition = startPosition + new Vector3(randomHorizontalOffset / 2f, popHeight, 0f); // Halfway horizontally
        Vector3 endPosition = startPosition + new Vector3(randomHorizontalOffset, 0f, 0f); // Land offset horizontally

        float elapsed = 0f;

        // Animate upwards with ease-in effect
        while (elapsed < popDuration / 2f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / (popDuration / 2f); // Normalized time (0 to 1)
            t = Mathf.SmoothStep(0f, 1f, t); // Ease-in/out effect
            transform.position = Vector3.Lerp(startPosition, peakPosition, t);
            yield return null;
        }

        // Animate downwards with ease-out effect
        elapsed = 0f;
        while (elapsed < popDuration / 2f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / (popDuration / 2f); // Normalized time (0 to 1)
            t = Mathf.SmoothStep(0f, 1f, t); // Ease-in/out effect
            transform.position = Vector3.Lerp(peakPosition, endPosition, t);
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
