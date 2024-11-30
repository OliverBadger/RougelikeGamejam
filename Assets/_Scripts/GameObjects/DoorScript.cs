using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool isUnlocked;

    private void OnEnable() 
    {
        GameManager.OnKeyPickedUp.AddListener(UnlockDoor);
    }

    private void OnDisable() 
    {
        GameManager.OnKeyPickedUp.RemoveListener(UnlockDoor);
    }

    private void UnlockDoor()
    {
        if(gameObject.CompareTag("Wall"))
        {
            isUnlocked = true;
            Debug.Log("Door is now unlocked");
            gameObject.active = false;
        }
        else if(gameObject.CompareTag("Door"))
        {
            //Add input for if its a door not a wall moving
            //This is for the gameobject being deactivated not for anything else
            //Different processors for each scenario.

        }
        
    }
}
