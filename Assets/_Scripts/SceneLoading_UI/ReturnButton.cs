using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
