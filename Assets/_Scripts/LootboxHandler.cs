using UnityEngine;

public class LootboxHandler : MonoBehaviour
{
  [Header("Prefabs to Spawn")]
    public GameObject[] lootPrefabs; // Array of prefabs to spawn (e.g., coins, weapons, items)
    public Transform spawnPoint; // Location where the loot will spawn
    public Sprite openedBox;

    [Header("Interaction Settings")]
    public KeyCode interactionKey = KeyCode.E; // Key to open the chest
    private bool isPlayerNearby = false; // Tracks if the player is near the chest
    private bool isChestOpened = false; // Tracks if the chest has already been opened
    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if the player is nearby and presses the interaction key
        if (isPlayerNearby && !isChestOpened && Input.GetKeyDown(interactionKey))
        {
            OpenChest();
        }
        if (Input.GetKeyDown(interactionKey))
        {
            Debug.Log("Someone has pressed e");
        }
        if (Input.GetKeyDown(interactionKey) && isPlayerNearby)
        {
            Debug.Log("Someone has pressed e nearby");
        }
    }

    private void OpenChest()
    {
        // Set the chest as opened
        isChestOpened = true;

        // Spawn the loot prefabs
        foreach (GameObject lootPrefab in lootPrefabs)
        {
            Instantiate(lootPrefab, spawnPoint.position, Quaternion.identity);
        }

        // Optional: Add visual or audio feedback (e.g., animation, sound effect)
        spriteRenderer.sprite = openedBox;
        Debug.Log("Chest opened! Loot spawned.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player is entering the chest's trigger
        if (other.tag == "Player")
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player is leaving the chest's trigger
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
