using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
// Define a UnityEvent for the key pickup
    public static UnityEvent OnKeyPickedUp = new UnityEvent();

    // This method can be called to trigger the event
    public static void KeyPickedUp()
    {
        OnKeyPickedUp.Invoke();
    }
}
