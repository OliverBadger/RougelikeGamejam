using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChaseCOmp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;
    private float chaseDistance = 2f;
    private float startChaseCounter;
    private readonly float startChaseCooldown = 2f;
    private bool isChasing;
    private Vector3 chaseStartPos;
    private Vector3 chaseEndPos;
    // Update is called once per frame
    private float chaseTimeCounter;
    private float chaseTime = 1f;
    void Start()
    {
        startChaseCounter = startChaseCooldown;
        isChasing = false;
        chaseTimeCounter = 2f;
    }
    void Update()
    {


        // After every 2 seconds, move towards the player by some set distance'
        if (startChaseCounter <= 0)
        {
            isChasing = true;
            startChaseCounter = startChaseCooldown;
            chaseStartPos = transform.position;
            chaseEndPos = Vector3.MoveTowards(transform.position, player.transform.position, chaseDistance);
        }
        else
        {
            startChaseCounter -= Time.deltaTime;
        }

        if (isChasing)
        {
            if (chaseTimeCounter > 0)
            {
                transform.position = Vector3.Lerp(chaseStartPos, chaseEndPos, 1 - chaseTimeCounter / chaseTime);

                chaseTimeCounter -= Time.deltaTime;
            }
            else
            {
                chaseTimeCounter = startChaseCooldown;
                isChasing = false;
            }
        }
    }


}
