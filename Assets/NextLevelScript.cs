using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));    
    }
}
