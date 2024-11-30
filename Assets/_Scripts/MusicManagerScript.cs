using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private static MusicManagerScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps music playing across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate music managers
        }
    }
}
