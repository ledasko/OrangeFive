using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    private PlayerController playerController;
    public int scoreValue;

    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        if(playerControllerObject == null)
        {
            Debug.Log("error");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerController.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
