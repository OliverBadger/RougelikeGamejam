using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneLoadingScript : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
