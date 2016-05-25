using UnityEngine;
using System.Collections;

public class GroundContact : MonoBehaviour
{

    PlayerHealth playerHealth;
    PlayerController playerController;
    public bool touchingGround;

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            touchingGround = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            touchingGround = false;
        }

    }

    void Update()
    {
        if (touchingGround)
        {
            playerHealth.AddFruitValue(playerHealth.healthDegen * -(playerController.moveSpeedStore - playerController.moveSpeed));
        }
    }
}
